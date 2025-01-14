// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

//  Provides data to be used when testing with international text

using System;

namespace Test.Uis.Data
{
    /// <summary>
    /// Provides information about interesting string values.
    /// </summary>
    public sealed class GlobalStringData
    {
        #region Constructors.        
        
        /// <summary>
        /// Initializes an instance of GlobalStringData class for the localeName
        /// </summary>        
        public GlobalStringData(string localeName)
        {                        
            this._localeName = localeName;
            switch (localeName)
            {
                case "Korean":
                    this._stringTypeSequence = koreanTypeSequence;
                    this._compositedString = koreanCompositedString;
                    break;
                case "Japanese":
                    this._stringTypeSequence = japaneseTypeSequence;
                    this._compositedString = japaneseCompositedString;
                    break;
                case "ChinesePinyin":
                    this._stringTypeSequence = chinesePinyinTypeSequence;
                    this._compositedString = chinesePinyinCompositedString;
                    break;
                case "ChineseQuanPin":
                    this._stringTypeSequence = chineseQuanPinTypeSequence;
                    this._compositedString = chineseQuanPinCompositedSequence;
                    break;
                default:
                    throw new NotSupportedException(localeName + " is not supported by this class");                    
            }            
        }

        #endregion


        #region Public properties.                       

        /// <summary>Name of the locale</summary>
        public string LocaleName
        {
            get
            {
                return _localeName;
            }
        }

        /// <summary>String to be typed (for programmatically injecting input) to get 
        /// (a localized) CompositedString</summary>
        public string StringTypeSequence
        {
            get
            {
                return _stringTypeSequence;
            }
        }

        /// <summary>String composited after typing StringTypeSequence</summary>
        public string CompositedString
        {
            get
            {
                return _compositedString;
            }
        }

        #endregion        


        #region Private fields.

        //Name of the locale
        private string _localeName;

        //String to be typed using KeyboardInput.TypeString
        private string _stringTypeSequence;

        //String composed after typed
        private string _compositedString;

        //Basic Korean characters followed by numbers
        private const string koreanTypeSequence = "rk sk ek fk ak qk tk dk wk ck zk ek vk gk 1234567890";
        private const string koreanCompositedString = "가 나 다 라 마 바 사 아 자 차 카 다 파 하 1234567890";
        
        //Translation of the Japanese sentence: The world of computers widens with Windows followed by numbers
        private const string japaneseTypeSequence = "uxindouzu{F7}de{ENTER}konpyu-ta{F7}no{ENTER}sekaiga{SPACE}hirogarimasu.{SPACE}{ENTER}1234567890{ENTER}";
        private const string japaneseCompositedString = "ウィンドウズでコンピュータの世界が広がります。１２３４５６７８９０";
                
        //Translation of the Chinese sentence: "How are you" followed by numbers
        private const string chinesePinyinTypeSequence = "nihao{SPACE}{SPACE}nihao{SPACE}{SPACE}nihao{SPACE}{SPACE}1234567890";
        private const string chinesePinyinCompositedString = "你好你好你好1234567890";                

        //Translation of the Chinese sentence: "How are you" followed by numbers
        private const string chineseQuanPinTypeSequence = "nihao{SPACE}nihao{SPACE}nihao{SPACE}1234567890";
        private const string chineseQuanPinCompositedSequence = "你好你好你好1234567890";

        #endregion
    }
}