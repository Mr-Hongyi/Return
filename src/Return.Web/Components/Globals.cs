using System;
namespace Return.Web.Components {
    public static class Globals {

        private static int _selectedId;
        public static int SelectedNoteId {
            get {
                return _selectedId;
            }
            set {
                _selectedId = value;
            }
        }
    }
}
