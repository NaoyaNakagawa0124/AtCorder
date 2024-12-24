#!/bin/bash

# 引数チェック
if [ $# -ne 1 ]; then
    echo "使用法: $0 -<コンテスト番号>"
    exit 1
fi

# コンテスト番号を取得
CONTEST=$(echo $1 | sed 's/^-//')

# フォルダ構造を作成
echo "フォルダ構造を作成します: $CONTEST"
mkdir -p "$CONTEST/TestCase"
mkdir -p "$CONTEST/Src"

# C#サンプルコードテンプレート
CS_TEMPLATE="using System;\nclass Program\n{\n    static int Main()\n    {\n        // サンプルコード\n        Console.WriteLine(\"Hello, AtCoder!\");\n        return 0;\n    }\n}"

# 問題ごとのファイルを作成
for PROBLEM in {A..G}; do
    SRC_FILE="$CONTEST/Src/ABC_${CONTEST}_${PROBLEM}.cs"
    if [ ! -f "$SRC_FILE" ]; then
        echo -e "$CS_TEMPLATE" > "$SRC_FILE"
        echo "作成しました: $SRC_FILE"
    else
        echo "スキップしました（既存ファイル）: $SRC_FILE"
    fi

    # TestCaseディレクトリ内にファイルを作成
    for TEST_CASE in {1..3}; do
        TEST_FILE="$CONTEST/TestCase/${PROBLEM}-${TEST_CASE}"
        if [ ! -f "$TEST_FILE" ]; then
            touch "$TEST_FILE"
            echo "作成しました: $TEST_FILE"
        else
            echo "スキップしました（既存ファイル）: $TEST_FILE"
        fi
    done
done

echo "フォルダ構造とサンプルファイルの作成が完了しました！"
