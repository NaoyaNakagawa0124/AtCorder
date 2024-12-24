#!/bin/bash

# 引数チェック
if [ $# -ne 3 ]; then
    echo "使用法: $0 <コンテスト番号> <C#ファイル名> <テストケース番号>"
    exit 1
fi

# 引数からコンテスト番号、C#ファイル名、テストケース番号を取得
CONTEST=$1
CS_FILE=$2
TEST_CASE=$3

# コンパイルディレクトリ（`exe`専用フォルダ）
EXE_DIR="$CONTEST/exe"
mkdir -p "$EXE_DIR"  # フォルダを作成

# C#ソースファイルと出力先
CS_PATH="$CONTEST/Src/$CS_FILE"
EXE_PATH="$EXE_DIR/${CS_FILE%.cs}.exe"

if [ ! -f "$CS_PATH" ]; then
    echo "エラー: ファイルが見つかりません -> $CS_PATH"
    exit 1
fi

# コンパイル
mcs -out:"$EXE_PATH" "$CS_PATH"
if [ $? -ne 0 ]; then
    echo "コンパイルエラー: $CS_FILE"
    exit 1
fi

# テストケースファイルを取得
TEST_FILE="$CONTEST/TestCase/$TEST_CASE"

if [ ! -f "$TEST_FILE" ]; then
    echo "エラー: テストケースファイルが見つかりません -> $TEST_FILE"
    exit 1
fi

if [ -s "$TEST_FILE" ]; then
    # 標準入力を取得し、末尾の改行を取り除く
    INPUT=$(sed '${/^$/d;}' "$TEST_FILE")

    # 標準入力を表示
    echo "$INPUT"

    # 標準入力をプログラムに渡して実行し、標準出力を表示
    echo "$INPUT" | mono "$EXE_PATH"
fi
