# Bomb_Roulette

> 「今日は俺が奢るよ」「いや、今日は俺が払うよ」  
> 勝負の行方は――ロシアンルーレットゲーム！

**リポジトリ名**: `Bomb_Roulette`  
**フレームワーク**: Unity (2021.3 LTS)
**チーム**: 情報技術研究会

---

## 作品説明

愛知工業大学のシステム工学研究会が主催した学生ハッカソンである「Syshack2025」で作成した作品です。
人生初めてのハッカソンで作成したものなので，デザインや技術力には目をつぶってもらえると嬉しいです。

---

## 📖 作品概要

友人同士の“奢り合い”に終止符を打つために生まれた、緊張感あふれるロシアンルーレット風ミニゲームです。
プレイヤーは順番に導火線を選択していき、爆発させてしまった人がアウト!
皆さんに奢ってあげてください!

---

## ✨ 主な特徴（ゲームの流れ）

- **導火線を選ぼう！**  
  自分のターンでは複数の導火線の中から1本を選びます。その先に爆弾が…！？

- **爆発したら即アウト！**  
  爆発させてしまった人がアウト!皆さんに奢ってあげてください!

- **爆発しなければ次のプレイヤーへバトンタッチ！**  
  生き延びたら、導火線はそのまま、次のプレイヤーのターンへ。

- **全員1回ずつ選んでも誰も爆発しなかったら？**  
  導火線がリセットされて、新たなラウンドへ突入！

- **3ラウンド経過でFinal Roundへ突入！**  
  最終ラウンドでは必ず誰かが爆発します！(無限ループ，マンネリの防止)

- **それでも分からないところがあったら**
  ゲーム内のヘルプウィンドウを確認してください!!

---

## 🚀 環境構築・実行手順

1. **リポジトリをクローン**  
   ```bash
   git clone https://github.com/your-organization/Bomb_Roulette.git
   cd Bomb_Roulette
   ```
   
2. **Unity プロジェクトを開く**  
   - Unity Hub から `Bomb_Roulette/` フォルダを追加  
   - Unity 2021.3 LTS 以上で開きます
      
3. **シーン切り替え**  
   - `Assets/Scenes/Title.unity` を開いて「再生 ▶︎」
     
4. **ビルド (オプション)**  
   - File → Build Settings → プラットフォーム選択 → Build  

---

## 📦 ディレクトリ構成

作っただけで使っていないC#クラス(ファイル)クラスがいくつかあるので，それはそのうち消します。

```
Bomb_Roulette/
├── Assets/
│   ├── Audio/
│   │   ├── Prehabs/
│   ├── Scenes/
│   │   ├── GameScene.unity
│   │   ├── ResultScene.unity
│   │   └── TitleScene.unity
│   ├── Scripts/
│   │   ├── Audio/
│   │   │   └── AudioManager.cs
│   │   ├── Config/
│   │   │   └── GameConfig.cs
│   │   ├── Core/
│   │   │   ├── DataManager.cs
│   │   │   ├── GameManager.cs
│   │   │   ├── PlayerManager.cs
│   │   │   ├── RoundManager.cs
│   │   │   └── TurnManager.cs
│   │   ├── Effects/
│   │   │   ├── ExplosionEffect.cs
│   │   │   ├── FakeExplosionEffect.cs
│   │   │   └── FuseEffect.cs
│   │   ├── Models/
│   │   │   ├── Bomb.cs
│   │   │   ├── FuseItem.cs
│   │   │   ├── FuseManager.cs
│   │   │   └── Player.cs
│   │   ├── UI/
│   │   │   ├── GameUI.cs
│   │   │   ├── ResultScreenUI.cs
│   │   │   └── TitleScreenUI.cs
│   │   └── Utilities/
│   │   │   └── Timer.cs
│   ├── Prefabs/
│   └── Videos/
├── Packages
├── ProjectSettings
└── README.md
```

---

## 📬 お問い合わせ

- Email: ankakesup@gmail.com 
