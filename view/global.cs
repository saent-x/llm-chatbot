namespace llm_chatbot.view;

public record struct ChatMessage(string from, string to, string message, DateTime timestamp);