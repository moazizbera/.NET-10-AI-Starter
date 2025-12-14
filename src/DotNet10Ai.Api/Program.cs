using DotNet10Ai.ConsoleApp;

// 1️⃣ App banner
Console.WriteLine("DotNet 10 AI Chat");
Console.WriteLine("Local • Ollama • Phi-3");
Console.WriteLine("Type /help for commands\n");

// 2️⃣ CREATE SESSION (HERE)
var session = new ChatSession();

// 3️⃣ ADD SYSTEM PROMPT (HERE — ONCE)
session.AddSystem(ChatSession.DefaultSystemPrompt);

// 4️⃣ CREATE CLIENT
var client = new OllamaChatClient("http://localhost:11434");

// 5️⃣ CHAT LOOP
while (true)
{
    Console.Write("You › ");
    var input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
        continue;

    if (input.Equals("/exit", StringComparison.OrdinalIgnoreCase))
        break;

    if (input.Equals("/clear", StringComparison.OrdinalIgnoreCase))
    {
        session.Clear(); // system prompt is re-added automatically
        Console.WriteLine("Conversation cleared.\n");
        continue;
    }

    if (input.Equals("/help", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("""
Commands:
  /help   Show commands
  /clear  Clear conversation
  /exit   Exit chat
""");
        continue;
    }

    // 6️⃣ USER MESSAGE
    session.AddUser(input);

    // 7️⃣ AI RESPONSE
    Console.Write("AI  › ");
    var reply = await client.StreamChatAsync(session.Messages);
    session.AddAssistant(reply);
}

// 8️⃣ EXIT
Console.WriteLine("\nGoodbye 👋");
