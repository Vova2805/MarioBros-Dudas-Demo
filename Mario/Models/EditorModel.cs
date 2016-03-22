using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_KPZ.Models.Facad
{
	[DataContract]
	class EditorModel
	{
		[DataMember]
		public string ControlType { get; set; }

		public EditorModel()
		{
			ControlType = "Option";
		}
	}
}
