@echo off
setlocal

if "%~1"=="" (
    echo 使用法: create_contest コンテスト番号
    echo 例: create_contest 384
    exit /b 1
)

set CONTEST=%~1
set CONTEST=%CONTEST:-=%

dotnet run --project "%~dp0ContentSetup.csproj" %CONTEST%