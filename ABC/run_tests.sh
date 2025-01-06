#!/bin/bash

# 引数チェック
if [ $# -lt 2 ]; then
    echo "使用法: $0 -<コンテスト番号> -<アルファベット>"
    exit 1
fi

# コンテスト番号とアルファベットを取得
CONTEST=$(echo $1 | sed 's/^-//')
PROBLEM_LETTER=$(echo $2 | sed 's/^-//')

# コンパイルディレクトリ（`exe`専用フォルダ）
EXE_DIR="$CONTEST/exe"
mkdir -p "$EXE_DIR"  # フォルダを作成

# C#ソースファイルと出力先
CS_FILE="ABC_${CONTEST}_${PROBLEM_LETTER}.cs"
CS_PATH="$CONTEST/Src/$CS_FILE"
EXE_PATH="$EXE_DIR/${CS_FILE%.cs}.exe"

# ソースファイルが存在するか確認
if [ ! -f "$CS_PATH" ]; then
    echo "エラー: ソースファイルが見つかりません -> $CS_PATH"
    exit 1
fi

# コンパイル
mcs -out:"$EXE_PATH" "$CS_PATH"
if [ $? -ne 0 ]; then
    echo "コンパイルエラー: $CS_FILE"
    exit 1
fi

# テストケースディレクトリの確認
TEST_DIR="$CONTEST/TestCase"
if [ ! -d "$TEST_DIR" ]; then
    echo "エラー: テストケースディレクトリが見つかりません -> $TEST_DIR"
    exit 1
fi

# テストケースを順番に実行
TEST_FILES=$(find "$TEST_DIR" -name "${PROBLEM_LETTER}-*" | sort)
if [ -z "$TEST_FILES" ]; then
    echo "エラー: 対応するテストケースが見つかりません -> $TEST_DIR/${PROBLEM_LETTER}-*"
    exit 1
fi

for TEST_FILE in $TEST_FILES; do
    if [ -s "$TEST_FILE" ]; then
        echo "--- 実行中: テストケース $TEST_FILE ---"
        # 標準入力を表示
        INPUT=$(sed '${/^$/d;}' "$TEST_FILE")
        echo "$INPUT"

        # 標準入力をプログラムに渡して実行
        echo "$INPUT" | mono "$EXE_PATH"
        echo ""
    else
        echo "スキップ: 空のテストケース $TEST_FILE"
    fi
done
