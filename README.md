# 🦖 Godzilla VR: Immersive Experience

**Final University Project – Immersive Technologies Module**  
Created with **Unity (2022.3 LTS)** + **Blender 4.3** + **Meta XR SDK** for **Meta Quest 3**

## 🎮 Overview

Become Godzilla in an immersive VR environment.  
Destroy a futuristic city, search for a **fusion reactor core**, and unleash the chaos with intuitive VR control – all while seated comfortably using Meta Quest 3 controllers.

> A seated VR experience focused on immersion, destruction mechanics, and full-body tracking integration.

---

## 📦 Features

- ✅ **Seated VR locomotion** using Meta Quest 3 thumbsticks
- ✅ **Godzilla full-body rig** with procedural tail and spine
- ✅ **Building destruction mechanics** (triggered by foot collision)
- ✅ **Fusion core retrieval gameplay objective**
- ✅ **Score system** based on building destruction and objective
- ✅ **Symbolic linking** for large assets (OneDrive integration)
- ✅ **Optimized for performance** using light geometry and mesh culling

---

## 🛠️ Tech Stack

| Tool               | Use                                |
|--------------------|-------------------------------------|
| **Unity 2022.3**   | Game engine                         |
| **Blender 4.3**    | 3D modeling and rigging             |
| **Meta XR SDK v74**| VR support (Camera Rig, Input, Body)|
| **Meta Movement SDK** | Optional advanced tracking (FT, ET, BT) |
| **OneDrive**       | External models storage (via symbolic link) |
| **GitHub**         | Project version control             |

---

## 🗂️ Project Structure

GodzillaVR/ ├── Assets/ │ ├── Models/ # Symbolically linked from OneDrive │ ├── Scripts/ # Game mechanics │ ├── Scenes/ # Main VR scene │ ├── Materials/ │ └── XR/ # Meta SDK & input tools ├── Packages/ ├── ProjectSettings/ ├── .gitignore └──
---

## 🚀 How to Run

1. Open Unity 2022.3
2. Make sure your **Meta XR SDK** and **XR Interaction Toolkit** are installed
3. Plug in your **Meta Quest 3** via **Link Cable** or **AirLink**
4. Press **Play** in Unity – headset mirrors the simulation

> If using OneDrive-linked models, make sure your paths are active and Unity is opened with **symlink support**.

---

## 🧪 To Do / In Progress

- [ ] Implement Godzilla hand-to-controller mapping
- [ ] Activate destruction logic with physics & pooling
- [ ] Add fusion core model & highlight interaction
- [ ] Implement scoring system UI
- [ ] Final polish pass & build for Quest APK

---

## 🧠 Credits

Created by [Michal Lazovy]  
Art Direction, Programming & Design by [Michal Lazovy]  
Inspired by **Kaiju lore** & modern VR interaction

---

## 📜 License

For academic use only – part of the Immersive Technologies coursework at Robert Gordon University.

