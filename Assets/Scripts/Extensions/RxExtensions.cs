using System;
using System.Collections;
using System.Threading;
using UniRx;

namespace Extensions
{
	public static class RxExtensions
	{
		public static IObservable<float> ToObservable(this UnityEngine.AsyncOperation asyncOperation)
		{
			if (asyncOperation == null) throw new ArgumentNullException(nameof(asyncOperation));

			return Observable.FromCoroutine<float>((observer, cancellationToken) => RunAsyncOperation(asyncOperation, observer, cancellationToken));
		}

		private static IEnumerator RunAsyncOperation(UnityEngine.AsyncOperation asyncOperation, IObserver<float> observer, CancellationToken cancellationToken)
		{
			while (!asyncOperation.isDone && !cancellationToken.IsCancellationRequested)
			{
				observer.OnNext(asyncOperation.progress);
				yield return null;
			}
			if (!cancellationToken.IsCancellationRequested)
			{
				observer.OnNext(asyncOperation.progress); // push 100%
				observer.OnCompleted();
			}
		}
	}
}