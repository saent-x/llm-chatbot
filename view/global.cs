using llm_chatbot.interfaces;
using Microsoft.AspNetCore.Components;

namespace llm_chatbot.view;

public record struct ChatMessage(string id, string sender, string message, DateTime timestamp);