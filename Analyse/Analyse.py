import os
import ast

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
    print(phase3)


def main():
    for element in os.listdir(path):
        if "_Data.txt" in element:
            if "_1-1_" in element:
                """Phase 1, block 1"""
                treatment_phase1(element,phase11)
                print(phase11)
            elif "_1-2_" in element:
                """Phase 1, block 2"""
                treatment_phase1(element, phase12)
                print(phase12)
            elif "_2-1_" in element:
                """Phase 2, block 1"""
                treatment_phase2(element, phase21)
                print(phase21)
            elif "_2-2_" in element:
                """Phase 1, block 2"""
                treatment_phase2(element, phase22)
                print(phase22)
            elif "_3-1_" in element:
                """Phase 3, block 1"""
                treatment_memorization(element)
                print(phase3)


if __name__ == '__main__':
    init()
    main()
