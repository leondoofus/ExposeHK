import os
import ast
import numpy as np
import matplotlib.pyplot as plt

path = "./../ExposeHK Interface/Experiment/AdvancedTextEditor_Source/TextRuler/TextRuler/bin/Debug"
buttons = ["btnCut", "btnCopy", "btnPaste", "btnUndo", "btnRedo", "DecreaseSizeBtn", "IncreaseSizeButton", "btnBold",
           "btnItalic", "btnUnderline", "btnStrikeThrough",
           "btnBulletedList", "btnNumberedList", "btnJustify", "btnAlignRight", "btnAlignCenter", "btnAlignLeft",
           "BlackButton", "MagentaButton", "LimeButton", "CyanButton"]
shortcuts = []

# print(shortcuts)
# print(len(buttons) == len(shortcuts))

phase11 = dict()
phase12 = dict()
phase21 = dict()
phase22 = dict()
phase3 = dict()

sum11 = dict()
sum12 = dict()
sum21 = dict()
sum22 = dict()
sum3 = dict()

anonyme = dict()
totaltime = dict()


def init():
    for tmp in ['X', 'C', 'V', 'Z', 'Y', '(', ')', 'B', 'I', 'U', 'Q', 'W', 'D', 'J', 'R', 'E', 'L', 'K', 'M', 'G',
                'H']:
        shortcuts.append("Ctrl + " + tmp)
    for i in ['ExposeHK', 'ExposeKeyboard', 'StickerKeyboard', 'Optimus']:
        phase11[i] = dict()
        phase12[i] = dict()
        phase21[i] = dict()
        phase22[i] = dict()
        phase3[i] = dict()
        sum11[i] = dict()
        sum12[i] = dict()
        sum21[i] = dict()
        sum22[i] = dict()
        sum3[i] = dict()


def treatment_phase1(filename, phase):
    print("File in treatment : %s" % filename)
    user, aid = filename.split("_")[0], filename.split("_")[1]
    f = open(os.path.join(path, filename), 'r')
    cptMouse = []
    cptKey = []
    for _ in buttons:
        cptMouse.append(0)
        cptKey.append(0)
    f.readline()
    for line in f:
        decompose = line.split(";")
        if decompose[7] == 'Hotkey':
            cptKey[buttons.index(decompose[6])] += 1
        else:
            cptMouse[buttons.index(decompose[6])] += 1
    phase[aid][user] = [cptMouse, cptKey]
    f.close()


def treatment_phase2(filename, phase):
    print("File in treatment : %s" % filename)
    user, aid = filename.split("_")[0], filename.split("_")[1]
    f = open(os.path.join(path, filename), 'r')
    cptMouse = []
    cptKey = []
    cptKeyAid = []
    for _ in buttons:
        cptMouse.append(0)
        cptKey.append(0)
        cptKeyAid.append(0)
    f.readline()
    for line in f:
        decompose = line.split(";")
        if decompose[7] == 'Hotkey':
            if ast.literal_eval(decompose[-1]):
                cptKeyAid[buttons.index(decompose[6])] += 1
            else:
                cptKey[buttons.index(decompose[6])] += 1
        else:
            cptMouse[buttons.index(decompose[6])] += 1
    phase[aid][user] = [cptMouse, cptKey, cptKeyAid]
    f.close()


def treatment_memorization(filename):
    print("File in treatment : %s" % filename)
    user, aid = filename.split("_")[0], filename.split("_")[1]
    f = open(os.path.join(path, filename), 'r')
    checkshct = []
    checklearn = []
    f.readline()
    for shct in shortcuts:
        line = f.readline()
        decompose = line.split(";")
        if shct in line:
            checkshct.append(True)
            # print(shct, line, True)
        else:
            checkshct.append(False)
            # print(shct, line, False)
        if decompose[7] == '0':  # learned by aid
            checklearn.append(True)
        else:
            checklearn.append(False)
    # print(user, aid)
    phase3[aid][user] = [checkshct, checklearn]
    # print(phase3)
    f.close()


def anonymize():
    i = 1
    print (phase11)
    for _, value in phase11.items():
        for name, _ in value.items():
            anonyme[name] = 'User' + str(i)
            i += 1
    print (anonyme)


def sum_action():
    for aid, liste in phase11.items():
        for name, value in liste.items():
            sum11[aid][name] = [sum(x) for x in zip(*value)]
    for aid, liste in phase12.items():
        for name, value in liste.items():
            sum12[aid][name] = [sum(x) for x in zip(*value)]
    for aid, liste in phase21.items():
        for name, value in liste.items():
            sum21[aid][name] = [sum(x) for x in zip(*value)]
    for aid, liste in phase22.items():
        for name, value in liste.items():
            sum22[aid][name] = [sum(x) for x in zip(*value)]


def draw_stackhisto():
    plot_stack_phase1(phase11, '_1-1')
    plot_stack_phase1(phase12, '_1-2')
    plot_stack_phase2(phase21, '_2-1')
    plot_stack_phase2(phase22, '_2-2')


def plot_stack_phase1(dataset, extension):
    N = len(buttons)
    tmp = []
    for item in buttons:
        tmp.append(item.replace('btn', '').replace('Btn', '').replace('Button', ''))
    ind = np.arange(N)  # the x locations for the groups
    width = 0.8  # the width of the bars: can also be len(x) sequence
    for _, liste in dataset.items():
        for name, value in liste.items():
            mouse = value[0]
            key = value[1]

            p1 = plt.bar(ind, mouse, width)
            p2 = plt.bar(ind, key, width, bottom=mouse)

            plt.gcf().subplots_adjust(bottom=0.25)
            plt.ylabel('Number of use')
            plt.title(anonyme[name] + '\'s Scores')
            plt.xticks(ind, tmp,
                       rotation=90)
            plt.yticks(np.arange(0, 22, 2))
            plt.legend((p1[0], p2[0]), ('Mouse', 'Key'))

            # plt.show()
            plt.savefig(anonyme[name] + extension, dpi=200)
            plt.clf()


def plot_stack_phase2(dataset, extension):
    N = len(buttons)
    tmp = []
    for item in buttons:
        tmp.append(item.replace('btn', '').replace('Btn', '').replace('Button', ''))
    ind = np.arange(N)  # the x locations for the groups
    width = 0.8  # the width of the bars: can also be len(x) sequence
    for _, liste in dataset.items():
        for name, value in liste.items():
            mouse = value[0]
            key = value[1]
            keyAid = value[2]

            p1 = plt.bar(ind, mouse, width)
            p2 = plt.bar(ind, key, width, bottom=mouse)
            p3 = plt.bar(ind, keyAid, width, bottom=key)

            plt.gcf().subplots_adjust(bottom=0.25)
            plt.ylabel('Number of use')
            plt.title(anonyme[name] + '\'s Scores')
            plt.xticks(ind, tmp,
                       rotation=90)
            plt.yticks(np.arange(0, 22, 2))
            plt.legend((p1[0], p2[0], p3[0]), ('Mouse', 'Key without aid displayed', 'Key with aid displayed'))

            # plt.show()
            plt.savefig(anonyme[name] + extension, dpi=200)
            plt.clf()


def main():
    # Data collection
    for element in os.listdir(path):
        if "_Data.txt" in element:
            if "_1-1_" in element:
                """Phase 1, block 1"""
                treatment_phase1(element, phase11)
                # print(phase11)
            elif "_1-2_" in element:
                """Phase 1, block 2"""
                treatment_phase1(element, phase12)
                # print(phase12)
            elif "_2-1_" in element:
                """Phase 2, block 1"""
                treatment_phase2(element, phase21)
                # print(phase21)
            elif "_2-2_" in element:
                """Phase 1, block 2"""
                treatment_phase2(element, phase22)
                # print(phase22)
            elif "_3-1_" in element:
                """Phase 3, block 1"""
                treatment_memorization(element)
                # print(phase3)
        else:
            if "Log.txt" in element and (
                    '_1-1_' in element or '_1-2_' in element or '_2-1_' in element or '_2-2_' in element):
                user, aid = element.split("_")[0], element.split("_")[1]
                f = open(os.path.join(path, element), 'r')
                if '-1' in element:
                    time = int(f.readlines()[-1].split(";")[1])
                else:
                    time = int(f.readlines()[-2].split(";")[1])
                if user in totaltime.keys():
                    totaltime[user].append(time)
                else:
                    totaltime[user] = [time]
                f.close()

    print (totaltime)
    anonymize()
    sum_action()
    draw_stackhisto()


if __name__ == '__main__':
    init()
    main()
