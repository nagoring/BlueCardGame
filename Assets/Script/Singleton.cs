using UnityEngine;


namespace Script
{
	public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
	{
		// シーンを跨いで値を保持するか
		protected abstract bool DontDestroy { get; }

		private static T instance;

		public static T I
		{
			get
			{
				// 値が参照されたタイミングで判定
				if (instance == null)
				{
					// nullだった場合は全オブジェクトを探索
					// 名前が一致するクラスがあった場合は取得する
					instance = FindObjectOfType<T>();

					// 名前が一致するものがなかった場合
					if (instance == null)
					{
						// コンソールウィンドウにエラーを出力
						Debug.LogError($"{typeof(T)}のインスタンスが存在しません。");
					}
				}

				return instance;
			}
		}

		// 継承先でもAwakeを呼び出したい場合は，overrideする
		protected virtual void Awake()
		{
			// 既に同一名のクラスが存在していた場合
			if (I != this)
			{
				// ゲームオブジェクトごと削除
				Destroy(gameObject);
				return;
			}

			if (DontDestroy)
			{
				DontDestroyOnLoad(gameObject);
			}
		}
	}
	
}