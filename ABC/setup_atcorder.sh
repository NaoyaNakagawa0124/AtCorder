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

# README.mdテンプレート
README_TEMPLATE="# ABC$CONTEST 進捗記録

## 解いた問題
| 問題 | 解答状況 | かかった時間 |
|------|----------|--------------|
| A    | 未着手 ❌ | -            |
| B    | 未着手 ❌ | -            |
| C    | 未着手 ❌ | -            |
| D    | 未着手 ❌ | -            |
| E    | 未着手 ❌ | -            |
| F    | 未着手 ❌ | -            |
| G    | 未着手 ❌ | -            |

**進捗状況**: 0/7

---

## 振り返り
### 問題A
- **取り組んだ日付**: 
- **解答時間**: 
- **感想**: 

### 問題B
- **取り組んだ日付**: 
- **解答時間**: 
- **感想**: 

### 問題C
- **取り組んだ日付**: 
- **解答時間**: 
- **感想**: 

---

## 復習記録
### 問題C
- **復習日付**: 
- **内容**: 
- **感想**: 

### 問題D
- **復習日付**: 
- **内容**: 
- **感想**: 

---

## 全体復習履歴
| 問題 | 初回取り組み日 | 復習日付 |
|------|----------------|----------|
| A    |                |          |
| B    |                |          |
| C    |                |          |
| D    |                |          |"

# README.mdを作成
README_FILE="$CONTEST/README.md"
if [ ! -f "$README_FILE" ]; then
    echo "$README_TEMPLATE" > "$README_FILE"
    echo "作成しました: $README_FILE"
else
    echo "スキップしました（既存ファイル）: $README_FILE"
fi

# C#サンプルコードテンプレート
CS_TEMPLATE="using System;\nusing System.Collections.Generic;\n\nclass Program\n{\n    static void Main()\n    {\n        string[] readline = Console.ReadLine().Split();\n    }\n}\n"

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
