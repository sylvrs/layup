# TODO: make this agnostic?
[windows]
set shell := ["powershell.exe", "-NoLogo", "-Command"]

build:
	dotnet build -c Release 

install path:
	cp "src/Layup.Core/bin/Release/net6.0/Layup.Core.dll"  "{{path}}"


run path: build (install path)

