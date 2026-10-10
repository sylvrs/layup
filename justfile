[windows]
set shell := ["powershell.exe", "-NoLogo", "-Command"]

build game_dir:
	dotnet build -c Release  "-p:HoopLandDir={{game_dir}}"

install game_dir:
	cp "src/Layup.API/bin/Release/net6.0/Layup.API.dll"  "{{game_dir}}/UserLibs"
	cp "src/Layup.Core/bin/Release/net6.0/FluentResults.dll"  "{{game_dir}}/UserLibs"
	cp "src/Layup.Core/bin/Release/net6.0/Layup.Core.dll"  "{{game_dir}}/Mods"
	&"{{game_dir}}/Hoop Land.exe"


run game_dir: (build game_dir) (install game_dir)

