# Zizo
# .NET AI Starter

A practical, step-by-step journey into building **AI-powered applications using modern .NET**.

This repository focuses on **real-world AI integration** — not hype, not theory — showing how .NET developers can work with Generative AI **without Python and without cloud dependencies**.

---

## 📌 Episodes Overview

- **Episode 1** – Vision, Architecture, and AI Fundamentals  
- **Episode 2** – Local AI Chat in Pure .NET (No Python) ✅  
- Episode 3 – AI API with ASP.NET (Coming Soon)  
- Episode 4 – Streaming AI APIs (SSE)  
- Episode 5 – RAG (Chat with Documents)  
- Episode 6 – UI Integration  

Each episode builds on the previous one and introduces complexity **only when it adds value**.

---

## 🚀 Episode 2 – Local AI Chat in Pure .NET

### 🎯 Goal

> **Prove that .NET can consume and integrate Generative AI models just as effectively as Python.**

This episode delivers a **local, streaming AI chat application built entirely in .NET**, using **Ollama** to run LLMs locally.

**No Python.**  
**No cloud APIs.**  
**No API keys.**  
**No cost.**

---

## 🧠 Why a Console Application?

The console app is **intentional**, not a shortcut.

- Removes ASP.NET and networking noise  
- Makes AI behavior easy to observe  
- Keeps focus on AI integration fundamentals  
- Ideal for learning and experimentation  

Web APIs and UI layers come in later episodes.

---

## 🛠 Technology Stack

- **.NET 9 / .NET 10 (preview-ready)**
- **C#**
- **Ollama** (local LLM runtime)
- **Phi-3** (example model)
- HTTP-based chat protocol
- Streaming responses (token-by-token)

---

## 📂 Repository Structure

```text
.NET-10-AI-Starter/
│
├── README.md
│
├── src/
│   ├── DotNet10Ai.Console/        ← Episode 2 (MAIN)
│   │   ├── Program.cs
│   │   ├── ConsoleUi.cs
│   │   ├── ChatSession.cs
│   │   ├── OllamaChatClient.cs
│   │   ├── Models/
│   │   │   └── ChatMessage.cs
│   │   └── DotNet10Ai.Console.csproj
│   │
│   └── DotNet10Ai.Api/            ← Episode 3+ (coming later)
│       └── (future content)
```

---

## ▶️ Run the Chat Application

From the repository root:

```bash
dotnet run --project src/DotNet10Ai.Console
```

You should see:

```text
DotNet AI Chat
Local • Ollama • Phi-3
Type /help for commands
```

---

## 💬 Chat Commands

| Command | Description |
|-------|------------|
| `/help` | Show available commands |
| `/clear` | Clear conversation history |
| `/exit` | Exit the chat |

---

## 🤖 How AI Is Used in This Project

- Chat messages are sent to Ollama using HTTP (`/api/chat`)
- Responses are streamed token-by-token
- A **system prompt** defines the AI role (senior software architect)
- Conversation history is preserved in memory
- No model training is performed

This mirrors how **production systems consume AI models**.

---

## 🆚 Do I Need Python for AI?

**Short answer: No.**

- **Python** dominates model training and AI research  
- **.NET** excels at AI integration, APIs, services, and production systems  

Most real-world applications **use models rather than train them**.

This project demonstrates that modern .NET is a **first-class option** for that role.

---

## 📚 What’s Coming Next

- Episode 3 – Non-streaming AI API with ASP.NET  
- Episode 4 – Streaming AI endpoints (SSE)  
- Episode 5 – RAG (chat with documents)  
- Episode 6 – UI integration  

Each step builds on a solid, proven foundation.

---

## 📄 License

MIT License
