# .NET AI Starter

A practical, step-by-step journey into building **AI-powered applications using modern .NET**.

This repository focuses on **real-world AI integration** — not hype — showing how .NET developers can work with Generative AI **without Python and without cloud dependencies**.

---

## 📌 Episodes Overview

- **Episode 1** – Vision, Architecture, and AI Fundamentals  
- **Episode 2** – Local AI Chat in Pure .NET (No Python) ✅  
- **Episode 3** – ASP.NET AI Web API (Local LLM) ✅  
- **Episode 4** – Conversation Memory & Prompt Engine  
- **Episode 5** – Streaming AI APIs (SSE)  
- **Episode 6** – RAG (Chat with Documents)  
- **Episode 7** – UI Integration  

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

- Removes ASP.NET and networking noise  
- Makes AI behavior visible  
- Keeps focus on AI integration fundamentals  
- Ideal for learning and experimentation  
- Provides a solid foundation for later API and UI layers  

---

## 🛠 Technology Stack (Episode 2)

- **.NET 9 / .NET 10 ready**  
- **C#**  
- **Ollama** (local LLM runtime)  
- **Phi-3** (example model)  
- HTTP-based chat protocol  
- Streaming responses (token-by-token)  

---

## 📂 Repository Structure (High Level)

```text
.NET-10-AI-Starter/
│
├── README.md
│
├── src/
│   ├── DotNet10Ai.Console/        ← Episode 2 (Console Chat)
│   └── DotNet10Ai.Api/            ← Episode 3 (Web API)
```

You can explore each project for more detailed structure.

---

## ▶️ Run the Console Chat (Episode 2)

From the repository root:

```bash
dotnet run --project src/DotNet10Ai.Console
```

You should see something like:

```text
DotNet AI Chat
Local • Ollama • Phi-3
Type /help for commands
```

---

## 💬 Chat Commands (Console)

| Command  | Description               |
|----------|---------------------------|
| `/help`  | Show available commands   |
| `/clear` | Clear conversation        |
| `/exit`  | Exit the chat application |

---

## 🤖 How AI Is Used in Episode 2

- Chat messages are sent to Ollama using HTTP (local endpoint)  
- Responses are streamed token-by-token  
- A **system prompt** defines the AI role (e.g., senior software architect)  
- Conversation history is preserved in memory (per run)  
- No model training is performed  

This mirrors how **production systems consume AI models**: they call models, they don’t train them.

---

## 🆚 Do I Need Python for This?

**Short answer: No.**

- **Python** dominates model training and research.  
- **.NET** excels at AI integration, APIs, services, and production systems.  

Most real-world applications **use models rather than train them**.  
This project demonstrates that modern .NET is a **first-class option** for that role.

---

# 📦 Episode 3 – ASP.NET AI Web API (Local LLM)

Episode 3 exposes the local AI engine through a clean **ASP.NET Web API**, making it available to any client that can speak HTTP.

### 🎯 Goal

Convert the local AI console engine into a reusable HTTP API that front-ends, tools, and services can call.

---

## 🌐 API Endpoint

**Route:**

```text
POST /api/chat
```

### 📥 Request Example

```json
{
  "message": "Hello"
}
```

### 📤 Response Example

```json
{
  "reply": "Hi! How can I assist you today?"
}
```

> The exact text will depend on your local model (e.g., Phi-3), but the shape of the response stays the same.

---

## 🔌 Technology (Episode 3)

- **ASP.NET Web API**  
- **Ollama** LLM runtime (local)  
- **Phi-3** (or another local model you configure)  
- JSON over HTTP  
- No cloud dependency  
- No Python requirement  

---

## ▶️ Run the Web API (Episode 3)

From the repository root:

```bash
dotnet run --project src/DotNet10Ai.Api
```

Then open Swagger UI in your browser:

```text
https://localhost:7085/swagger
```

From Swagger:

1. Open the `POST /api/chat` endpoint.  
2. Click **Try it out**.  
3. Use a body such as:  

   ```json
   {
     "message": "Explain .NET 10 in one paragraph."
   }
   ```

4. Click **Execute** and inspect the JSON reply.

---

## 🤝 Episode 3 Outcome

After Episode 3, the project now supports:

- Local LLM inference exposed over HTTP  
- Integration with **any** front-end (web, mobile, desktop)  
- A clean separation between **AI engine** and **API layer**  
- A ready foundation for:  
  - Conversation memory (Episode 4)  
  - Streaming APIs (Episode 5)  
  - RAG and document chat (Episode 6)  
  - Rich UI (Episode 7)  

---

## 📚 Coming Next

Planned upcoming episodes in this series:

- **Episode 4** – Conversation Memory & Prompt Engine  
- **Episode 5** – Streaming AI APIs (SSE)  
- **Episode 6** – RAG (Chat with Documents)  
- **Episode 7** – UI Integration  

Each step builds on a solid, working foundation from the previous episodes.

---

## 📄 License

This project is licensed under the **MIT License**.
