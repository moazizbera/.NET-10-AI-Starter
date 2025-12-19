# .NET AI Starter

A practical, step-by-step journey into building **AI-powered applications using modern .NET**.

This repository focuses on **real-world AI integration** — not hype, showing how .NET developers can work with Generative AI **without Python and without cloud dependencies**.

---

## 📌 Episodes Overview

- **Episode 1** – Vision, Architecture, and AI Fundamentals  
- **Episode 2** – Local AI Chat in Pure .NET (No Python) ✅  
- **Episode 3** – ASP.NET AI Web API (Local LLM) ✅  
- **Episode 4** – Streaming AI APIs (SSE)  
- **Episode 5** – RAG (Chat with Documents)  
- **Episode 6** – UI Integration  

Each episode builds on the previous one and introduces complexity **only when it adds value**.

---

## 🚀 Episode 2 – Local AI Chat in Pure .NET

### 🎯 Goal
> Prove that .NET can consume and integrate Generative AI models just as effectively as Python.

This episode delivers a **local, streaming AI chat application built entirely in .NET**, using **Ollama** to run LLMs locally.

- No Python  
- No cloud APIs  
- No API keys  
- Zero cost  

---

## 🧠 Why a Console Application?
The console app is intentional:

- Removes ASP.NET noise  
- Makes AI behavior visible  
- Ideal for experimentation  
- Foundation for later layers  

---

## 🛠 Tech Stack
- .NET 9 / .NET 10 ready  
- C#  
- Ollama local runtime  
- Phi-3 model  
- Streaming token responses  

---

## 📂 Repository Structure

.NET-10-AI-Starter/
│
├── README.md
│
├── src/
│   ├── DotNet10Ai.Console/        ← Episode 2 (MAIN)
│   ├── DotNet10Ai.Api/            ← Episode 3 (Web API)


---

## ▶️ Run the Console Chat

dotnet run --project src/DotNet10Ai.Console

Expected:
DotNet AI Chat
Local • Ollama • Phi-3
/help for commands

---

## 💬 Chat Commands

/help  
/clear  
/exit  

---

## 🤖 How AI Works Here

- Messages sent to Ollama HTTP endpoints  
- System prompt defines role  
- Token streaming  
- No training performed  
- Production-style inference  

---

## 🆚 Do I Need Python?

**No.**

Python is dominant in research.  
.NET is excellent for AI integration, APIs, and production systems.

This repo demonstrates .NET as a **first-class AI runtime**.

---

# 📦 Episode 3 – ASP.NET AI Web API

Episode 3 exposes the model through a clean .NET Web API.

### 🎯 Goal
Convert the local AI engine into a reusable HTTP API.

### Endpoint
POST /api/chat

### Request Example
{ "message": "Hello" }

### Response Example
{ "reply": "Hi! How can I assist you today?" }

### 🔌 Technology
ASP.NET Web API  
Ollama LLM runtime  
Phi-3 local model  
JSON over HTTP  
No cloud dependency  

---

## ▶️ Run the Web API

dotnet run --project src/DotNet10Ai.Api

Visit Swagger:
/swagger

---

# 📚 Coming Next

Episode 4 – Streaming AI endpoint (SSE)  
Episode 5 – RAG with documents  
Episode 6 – UI integration  

---

# 📄 License
MIT License
