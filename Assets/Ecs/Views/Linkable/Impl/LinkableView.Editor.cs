#if UNITY_EDITOR
using JCMG.EntitasRedux;
using UnityEditor;

namespace Ecs.Views.Linkable.Impl
{
	public abstract partial class LinkableView
	{
		private void OnValidate()
		{
			_entityLink = GetComponent<EntityLink>();
		}
	}
}
#endif