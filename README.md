# 🃏 Solitaire Prototype (Unity 2022)

This is a small prototype of a Solitaire game built in Unity 2022.3.20f1. It includes core card mechanics such as card stacks, drag-and-drop card movement, and basic undo functionality implemented using the Command pattern for scalability.

---

## ✅ What’s Included

- Drag-and-drop card movement between stacks
- Multi-card dragging (e.g. dragging a whole run of cards)
- Undo functionality using the Command pattern
- Modular codebase designed for extension

---

## 🧠 AI Assistance

I used ChatGPT (in this chat) to help generate:

- Project structure and script layout
- Modular `Card`, `CardStack`, and drag handler systems
- Multi-card drag-and-drop implementation
- Fixes for Unity UI-based drag logic
- This README file

I prompted ChatGPT with specific needs like "multi-card dragging using UI raycasts" or "fix Input.mousePosition on canvas", and iteratively refined code with its feedback.

---

## 🔧 What I’d Improve With More Time

- Add polished animations for movement, flips, and card stacking
- Introduce more solitaire mechanics (e.g. auto-move to foundation, deck draw)
- Create a system for chaining/undoing a broader set of commands (e.g. auto-flip, auto-complete)
- Add sound and visual polish (e.g. highlights, glow, transitions)
- Add card skin switching or theming

---

## ▶️ How to Use

1. Open the project in **Unity 2022.3.20f1**
2. Open the scene: `SolitaireUndo/Assets/Scenes/SampleScene.unity`
3. Press **Play** in the Unity Editor
4. **Drag and drop** cards between stacks
5. Press the **Undo** button in the **bottom-right corner** to undo the last move
6. Best experienced in **portrait orientation** (e.g. 9:16 or phone aspect ratio)

---

Enjoy!