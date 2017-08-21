using System;
using System.ComponentModel;

namespace WhatsNewInCSharp7
{
	public sealed class ExpressedPerson
		: INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private int id;
		private string name;

		public ExpressedPerson(int id) => this.id = id;

		public ExpressedPerson(int id, string name)
			: this(id) => this.name = name ?? throw new ArgumentNullException(nameof(name));

		private void SetProperty<T>(string propertyName, T newValue, ref T currentValue)
			where T : IEquatable<T>
		{
			if (!newValue.Equals(currentValue))
			{
				currentValue = newValue;
				this.PropertyChanged?.Invoke(
					this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public int Id
		{
			get => this.id;
			set => this.SetProperty(nameof(this.Id), value, ref this.id);
		}

		public string Name
		{
			get => this.name;
			set => this.SetProperty(nameof(this.Name), value, ref this.name);
		}
	}
}
