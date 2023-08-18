namespace EFarm.Client
{
	public class AppState
	{
		public event Action OnStateChange;
		private void NotifyStateChanged() => OnStateChange?.Invoke();
	}
}
