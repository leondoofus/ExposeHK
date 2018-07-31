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
    print (phase11)
    for aid, value in phase11.items():
        i = 1
        for name, _ in value.items():
            anonyme[name] = aid + ' User' + str(i)
            i += 1
    print (anonyme)


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
    width = 0.4  # the width of the bars: can also be len(x) sequence
    for _, liste in dataset.items():
        for name, value in liste.items():
            mouse = value[0]
            key = value[1]

            p1 = plt.bar(ind - 0.2, mouse, width)
            p2 = plt.bar(ind + 0.2, key, width)

            plt.gcf().subplots_adjust(bottom=0.25)
            plt.ylabel('Number of use')
            plt.title(anonyme[name] + extension.replace('_', ' Phase ') + '\'s Uses')
            plt.xticks(ind, tmp, rotation=90)
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
    width = 0.2  # the width of the bars: can also be len(x) sequence
    for _, liste in dataset.items():
        for name, value in liste.items():
            mouse = value[0]
            key = value[1]
            keyAid = value[2]

            p1 = plt.bar(ind - 0.2, mouse, width)
            p2 = plt.bar(ind, key, width)
            p3 = plt.bar(ind + 0.2, keyAid, width)

            plt.gcf().subplots_adjust(bottom=0.25)
            plt.ylabel('Number of use')
            plt.title(anonyme[name] + extension.replace('_', ' bloc ') + '\'s Uses')
            plt.xticks(ind, tmp, rotation=90)
            plt.legend((p1[0], p2[0], p3[0]), ('Mouse', 'Key without aid displayed', 'Key with aid displayed'))

            # plt.show()
            plt.savefig(anonyme[name] + extension, dpi=200)
            plt.clf()


def draw_scores():
    N = len(anonyme)
    score = []
    users = []
    ind = np.arange(N)  # the x locations for the groups
    width = 0.8  # the width of the bars: can also be len(x) sequence
    learned_percent = []
    learned_score = []
    for aid, liste in phase3.items():
        for name, value in liste.items():
            users.append(anonyme[name])
            tmp = 0
            for i in range(len(buttons)):
                if value[1][i]:
                    if value[0][i]:
                        tmp += 1
            learned_score.append(tmp)
            learned_percent.append(tmp * 100 / sum(value[1]))
            score.append(sum(value[0]) - tmp)

    p1 = plt.bar(ind, score, width, bottom=learned_score)
    p2 = plt.bar(ind, learned_score, width)
    plt.gcf().subplots_adjust(bottom=0.4)
    plt.ylabel('Number of remembered shortcuts')
    plt.title('All users\' Scores')
    plt.xticks(ind, users, rotation=90)
    plt.yticks(np.arange(0, len(buttons) + 1, 2))
    plt.legend((p1[0], p2[0]), ('Remembered shortcuts by nature', 'Remembered shortcuts by using visual aid'))
    # plt.show()
    plt.savefig('Scores phases3 learning', dpi=200)
    plt.clf()

    plt.bar(ind, learned_percent, width)
    plt.gcf().subplots_adjust(bottom=0.4)
    plt.ylabel('Number of remembered shortcuts')
    plt.title('All users\' Remember Rate')
    plt.xticks(ind, users, rotation=90)
    plt.yticks(np.arange(0, 110, 20))
    # plt.show()
    plt.savefig('Scores phases3 learning rate', dpi=200)
    plt.clf()


def draw_time():
    N = len(anonyme.keys())
    ind = np.arange(N)  # the x locations for the groups
    width = 0.2  # the width of the bars: can also be len(x) sequence
    users = sorted(anonyme.values())
    tmp = [[], [], [], []]
    for user in users:
        for name, t in totaltime.items():
            if anonyme[name] == user:
                tmp[0].append(t[0])
                tmp[1].append(t[1])
                tmp[2].append(t[2])
                tmp[3].append(t[3])
    p1 = plt.bar(ind - 0.3, tmp[0], width)
    p2 = plt.bar(ind - 0.1, tmp[1], width)
    p3 = plt.bar(ind + 0.1, tmp[2], width)
    p4 = plt.bar(ind + 0.3, tmp[3], width)

    plt.gcf().subplots_adjust(bottom=0.4)
    plt.title('All Users\' Editing Time')
    plt.xticks(ind, users, rotation=90)
    plt.yticks(np.arange(0, 510000, 50000))
    plt.legend((p1[0], p2[0], p3[0], p4[0]), ('Bloc 1.1', 'Bloc 1.2', 'Bloc 2.1', 'Bloc 2.2'))

    # plt.show()
    plt.savefig('Time', dpi=200)
    plt.clf()


def draw_time2():
    N = 4
    ind = np.arange(N)  # the x locations for the groups
    techniques = ['ExposeHK', 'ExposeKeyboard', 'StickerKeyboard', 'Optimus']
    tmp = [[], [], [], []]
    for t in range(len(techniques)):
        s1, s2, s3, s4 = 0, 0, 0, 0
        i = 0
        for name, time in totaltime.items():
            if techniques[t] in anonyme[name]:
                print(name, t)
                i += 1
                s1 += time[0]
                s2 += time[1]
                s3 += time[2]
                s4 += time[3]
        tmp[t].append(float(s1) / float(i))
        tmp[t].append(float(s2) / float(i))
        tmp[t].append(float(s3) / float(i))
        tmp[t].append(float(s4) / float(i))

    p1 = plt.plot(tmp[0], 'gh-.')
    p2 = plt.plot(tmp[1], 'bh-.')
    p3 = plt.plot(tmp[2], 'rh-.')
    p4 = plt.plot(tmp[3], 'yh-.')

    plt.title('Editing Time by Technique')
    plt.xticks(ind, ('Phase 1-1', 'Phase 1-2', 'Phase 2-1', 'Phase 2-2'))
    plt.legend((p1[0], p2[0], p3[0], p4[0]), techniques, loc=1)

    # plt.show()
    plt.savefig('TimeTechnique', dpi=200)
    plt.clf()


def draw_shortcut():
    N = len(shortcuts)
    tx = []
    for item in buttons:
        tx.append(item.replace('btn', '').replace('Btn', '').replace('Button', ''))
    ind = np.arange(N)  # the x locations for the groups
    width = 0.2  # the width of the bars: can also be len(x) sequence
    aid1, aid2, aid3, aid4 = [], [], [], []
    for _ in shortcuts:
        aid1.append(0)
        aid2.append(0)
        aid3.append(0)
        aid4.append(0)
    print (phase3)
    tmp = ['ExposeHK', 'ExposeKeyboard', 'StickerKeyboard', 'Optimus']
    for aid, liste in phase3.items():
        for _, value in liste.items():
            if aid == tmp[0]:
                for i in range(len(value[0])):
                    if value[0][i]:
                        aid1[i] += 1
            if aid == tmp[1]:
                for i in range(len(value[0])):
                    if value[0][i]:
                        aid2[i] += 1
            if aid == tmp[2]:
                for i in range(len(value[0])):
                    if value[0][i]:
                        aid3[i] += 1
            if aid == tmp[3]:
                for i in range(len(value[0])):
                    if value[0][i]:
                        aid4[i] += 1

    p1 = plt.bar(ind - 0.3, aid1, width)
    p2 = plt.bar(ind - 0.1, aid2, width)
    p3 = plt.bar(ind + 0.1, aid3, width)
    p4 = plt.bar(ind + 0.3, aid4, width)
    plt.gcf().subplots_adjust(bottom=0.25)
    plt.ylabel('Number of users')
    plt.title('Shortcut retrievement')
    plt.yticks(np.arange(0, 5, 1))
    plt.xticks(ind, tx, rotation=90)
    plt.legend((p1[0], p2[0], p3[0], p4[0]), tmp)
    # plt.show()
    plt.savefig('Shortcut retrievement', dpi=200)
    plt.clf()


def draw_shortcut_rate():
    N = 4
    ind = np.arange(N)  # the x locations for the groups
    techniques = ['ExposeHK', 'ExposeKeyboard', 'StickerKeyboard', 'Optimus']
    tmp = [[], [], [], []]
    for t in range(len(techniques)):
        t1, t2, t3, t4 = 0, 0, 0, 0
        s1, s2, s3, s4 = 0, 0, 0, 0
        for name, value in phase11[techniques[t]].items():
            if techniques[t] in anonyme[name]:
                s1 += sum(value[1])
                t1 += sum(value[0])
        for name, value in phase12[techniques[t]].items():
            if techniques[t] in anonyme[name]:
                s2 += sum(value[1])
                t2 += sum(value[0])
        for name, value in phase21[techniques[t]].items():
            if techniques[t] in anonyme[name]:
                s3 += sum(value[1]) + sum(value[2])
                t3 += sum(value[0])
        for name, value in phase22[techniques[t]].items():
            if techniques[t] in anonyme[name]:
                s4 += sum(value[1]) + sum(value[2])
                t4 += sum(value[0])
        tmp[t].append(float(s1 * 100) / float(s1 + t1))
        tmp[t].append(float(s2 * 100) / float(s2 + t2))
        tmp[t].append(float(s3 * 100) / float(s3 + t3))
        tmp[t].append(float(s4 * 100) / float(s4 + t4))

    p1 = plt.plot(tmp[0], 'gh-.')
    p2 = plt.plot(tmp[1], 'bh-.')
    p3 = plt.plot(tmp[2], 'rh-.')
    p4 = plt.plot(tmp[3], 'yh-.')

    plt.title('Shortcut Rate by Technique')
    plt.xticks(ind, ('Phase 1-1', 'Phase 1-2', 'Phase 2-1', 'Phase 2-2'))
    plt.legend((p1[0], p2[0], p3[0], p4[0]), techniques, loc=2)

    # plt.show()
    plt.savefig('RateTechnique', dpi=200)
    plt.clf()

    tmp = [[], []]
    techniques = ['ExposeHK', 'ExposeKeyboard']
    for t in range(len(techniques)):
        t3, t4 = 0, 0
        s3, s4 = 0, 0
        for name, value in phase21[techniques[t]].items():
            if techniques[t] in anonyme[name]:
                s3 += sum(value[2])
                t3 += sum(value[0]) + sum(value[1])
        for name, value in phase22[techniques[t]].items():
            if techniques[t] in anonyme[name]:
                s4 += + sum(value[2])
                t4 += sum(value[0]) + sum(value[1])
        tmp[t].append(float(s3 * 100) / float(s3 + t3))
        tmp[t].append(float(s4 * 100) / float(s4 + t4))

    p1 = plt.plot(tmp[0], 'gh-.')
    p2 = plt.plot(tmp[1], 'bh-.')

    plt.title('Shortcut Rate without Visual aid by Technique')
    plt.xticks(np.arange(2), ('Phase 2-1', 'Phase 2-2'))
    plt.legend((p1[0], p2[0]), techniques, loc=5)

    # plt.show()
    plt.savefig('Rate without aid Technique', dpi=200)
    plt.clf()


def draw_nature():
    N = len(buttons)
    ind = np.arange(N)  # the x locations for the groups
    width = 0.8  # the width of the bars: can also be len(x) sequence
    tmp = []
    nature = []
    for item in buttons:
        tmp.append(item.replace('btn', '').replace('Btn', '').replace('Button', ''))
        nature.append(0)
    for aid, liste in phase3.items():
        for name, value in liste.items():
            for i in range(len(buttons)):
                if not value[1][i]:
                    if value[0][i]:
                        nature[i] += 1

    nature, tmp = zip(*sorted(zip(nature, tmp), key=lambda shortcut: shortcut[0], reverse=True))
    p1 = plt.bar(ind, nature, width)
    plt.gcf().subplots_adjust(bottom=0.25)
    plt.title('Known Shortcut by Nature')
    plt.xticks(ind, tmp, rotation=90)

    # plt.show()
    plt.savefig('Nature', dpi=200)
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

    anonymize()
    # draw_stackhisto()
    # draw_scores()
    # draw_time()
    # draw_shortcut()
    # draw_time2()
    # draw_shortcut_rate()
    draw_nature()


if __name__ == '__main__':
    init()
    main()
