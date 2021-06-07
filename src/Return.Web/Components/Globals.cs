using System;
namespace Return.Web.Components {
    using Application.RetrospectiveLanes.Queries;
    using System.Collections.Generic;
    public static class Globals {

        private static int _selectedId;
        private static bool _groupingBool;
        private static bool _exitingBool = false;
        private static RetrospectiveLaneContent _contentsStart = default!;
        private static RetrospectiveLaneContent _contentsStop = default!;
        private static RetrospectiveLaneContent _contentsContinue = default!;

        public static bool Exiting {
            get {
                return _exitingBool;
            }
            set {
                _exitingBool = value;
            }
        }

        public static bool Grouping {
            get {
                return _groupingBool;
            }
            set {
                _groupingBool = value;
            }
        }


        public static RetrospectiveLaneContent ContentsStart {
            get {
                return _contentsStart;
            }
            set {
                _contentsStart = value;
            }
        }

        public static RetrospectiveLaneContent ContentsStop {
            get {
                return _contentsStop;
            }
            set {
                _contentsStop = value;
            }
        }

        public static RetrospectiveLaneContent ContentsContinue {
            get {
                return _contentsContinue;
            }
            set {
                _contentsContinue = value;
            }
        }

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
