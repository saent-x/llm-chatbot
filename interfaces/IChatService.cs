
using llm_chatbot.view;

namespace llm_chatbot.interfaces;

public interface IChatService{
    string? Username { get; set; }
    List<ChatMessage> chatMessages { get; set; }
    void SetUsername(string value);
    void GenerateResponse();
    void StopResponse();
    void DeleteMessage(int id);
    void ClearScreen();
    void ClearMessages();
}