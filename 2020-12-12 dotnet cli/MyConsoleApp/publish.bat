@echo off
rd /s/q dist
dotnet publish --output dist --runtime win-x64 --configuration Release --self-contained
