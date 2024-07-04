package main

import (
	"fmt"
	"github.com/a-h/templ"
	"github.com/saent-x/llm-chatbot/src/views"
	"net/http"
)

func main() {

	app := views.Home("Johnpaul, welcome home")
	chat_screen := views.ChatScreen()

	http.Handle("/", templ.Handler(app))
	http.Handle("/chat", templ.Handler(chat_screen))

	fmt.Println("server starting on localhost:3000")

	err := http.ListenAndServe(":3000", nil)
	if err != nil {
		panic(err)
	}
}
