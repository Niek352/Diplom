using Ecs.Views.Linkable.Impl;
using UnityEngine;

namespace Db.Player.Impl
{
	[CreateAssetMenu(menuName = "Settings/" + nameof(PlayerData), fileName = nameof(PlayerData))]
	public class PlayerData : ScriptableObject, IPlayerData
	{
		[SerializeField] private PlayerView _playerView;
		
		public PlayerView PlayerView => _playerView;
	}
}