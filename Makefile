.PHONY: all web tailwind

all:
	web tailwind

web:
	dotnet watch

tailwind:
	tailwind -i wwwroot/app.css -o wwwroot/app.min.css --watch