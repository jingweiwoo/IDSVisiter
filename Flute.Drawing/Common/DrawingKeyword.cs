using System;
using System.Collections.Generic;
using System.Text;

namespace Flute.Drawing
{
    #region .KeywordLocation.
    public class KeywordLocation
    {
        public string ID { get; set; }
        public Int32 Page { get; set; }
        public string Cell { get; set; }

        public KeywordLocation()
        {
            Page = 0;
            Cell = "";
            ID = Cell + "-" + Page.ToString();
        }

        public KeywordLocation(Int32 page, string cell)
        {
            Page = page;
            Cell = cell;
            ID = Cell + "-" + Page.ToString();
        }

        public KeywordLocation Copy()
        {
            return this.MemberwiseClone() as KeywordLocation;
        }
    }

    public class KeywordLocationCollection : List<KeywordLocation>
    {
        public KeywordLocationCollection()
        {
        }

        #region .Key Index.

        public KeywordLocation this[string id]
        {
            get
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].ID == id)
                            return (KeywordLocation)this[i];
                    }
                    return null;
                }
                else
                    return null;
            }
            set
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].ID == id) {
                            this[i] = value;
                            break;
                        }
                    }
                }
                else
                    throw new System.ArgumentOutOfRangeException("Keyword Location Index", "No Keyword Location with this ID can be found");
            }
        }

        #endregion // Key Index

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public KeywordLocationCollection Copy()
        {
            KeywordLocationCollection keywordLocations = new KeywordLocationCollection();

            if (this.Count <= 0)
                return keywordLocations;
            else {
                foreach (KeywordLocation keywordLocation in this)
                    keywordLocations.Add(keywordLocation.Copy());
                return keywordLocations;
            }
        }

        #endregion // Copy

        #region .Comparer.

        public static int Comparer(KeywordLocation x, KeywordLocation y)
        {
            if (x.ID == null) {
                if (y.ID == null) {
                    // If x.ID is null and y.ID is null, they're
                    // equal. 
                    return 0;
                }
                else {
                    // If x.ID is null and y.ID is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else {
                // If x.Tag is not null...
                //
                if (y.ID == null)
                // ...and y.ID is null, x.ID is greater.
                {
                    return 1;
                }
                else {
                    return string.Compare(x.ID, y.ID /*, true, System.Globalization.CultureInfo.InstalledUICulture*/);
                }
            }
        }

        #endregion // Comparer

        #region .Sort.

        public void Sort()
        {
            base.Sort(KeywordLocationCollection.Comparer);
        }

        #endregion

        #region .ContainsLocation.

        public bool ContainsLocation(string id)
        {
            if (this.Count <= 0)
                return false;
            else
                foreach (KeywordLocation keywordLocation in this) {
                    if (keywordLocation.ID == id)
                        return true;
                }

            return false;
        }

        #endregion

        #region .AddLocation.
        public void AddLocation(KeywordLocation keywordLocation)
        {
            if (this.ContainsLocation(keywordLocation.ID) == true)
                return;
            else
                this.Add(keywordLocation.Copy());
        }

        public void AddLocations(KeywordLocationCollection keywordLocations)
        {
            if (keywordLocations != null && keywordLocations.Count > 0)
                foreach (KeywordLocation keywordLoaction in keywordLocations)
                    this.AddLocation(keywordLoaction);
            else
                return;
            return;
        }

        public void AddLocations(params KeywordLocation[] keywordLocations)
        {
            if (keywordLocations != null && keywordLocations.Length > 0)
                foreach (KeywordLocation keywordLoaction in keywordLocations)
                    this.AddLocation(keywordLoaction);
            else
                return;
            return;
        }

        #endregion

    }
    #endregion

    #region .KeywordInOtherLanguage.
    public class KeywordInOtherLanguage
    {
        public DrawingLanguage Language { get; set; }
        public string Translated { get; set; }

        public KeywordInOtherLanguage()
        {
            Language = DrawingLanguage.English;
            Translated = "";
        }

        public KeywordInOtherLanguage(DrawingLanguage language, string translated)
        {
            Language = language;
            Translated = translated;
        }

        public KeywordInOtherLanguage Copy()
        {
            return this.MemberwiseClone() as KeywordInOtherLanguage;
        }
    }

    public class KeywordInOtherLanguageCollection : List<KeywordInOtherLanguage>
    {
        public KeywordInOtherLanguageCollection()
        {
        }

        #region .Key Index.

        public KeywordInOtherLanguage this[DrawingLanguage language]
        {
            get
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].Language == language)
                            return (KeywordInOtherLanguage)this[i];
                    }
                    return null;
                }
                else
                    return null;
            }
            set
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].Language == language) {
                            this[i] = value;
                            break;
                        }
                    }
                }
                else
                    throw new System.ArgumentOutOfRangeException("Keyword In Other Language Index", "No Loop with this Language can be found");
            }
        }

        #endregion // Key Index

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public KeywordInOtherLanguageCollection Copy()
        {
            KeywordInOtherLanguageCollection keywordsInOtherLanguage = new KeywordInOtherLanguageCollection();

            if (this.Count <= 0)
                return keywordsInOtherLanguage;
            else {
                foreach (KeywordInOtherLanguage keywordInOtherLanguage in this)
                    keywordsInOtherLanguage.Add(keywordInOtherLanguage.Copy());
                return keywordsInOtherLanguage;
            }
        }

        #endregion // Copy

        #region .Comparer.

        public static int Comparer(KeywordInOtherLanguage x, KeywordInOtherLanguage y)
        {
            if (x.Language == null) {
                if (y.Language == null) {
                    // If x.Language is null and y.Language is null, they're
                    // equal. 
                    return 0;
                }
                else {
                    // If x.Language is null and y.Language is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else {
                // If x.Language is not null...
                //
                if (y.Language == null)
                // ...and y.Language is null, x.Language is greater.
                {
                    return 1;
                }
                else {
                    if (Convert.ToInt32(x.Language) < Convert.ToInt32(y.Language))
                        return -1;
                    else if (Convert.ToInt32(x.Language) == Convert.ToInt32(y.Language))
                        return 0;
                    else
                        return 1;
                }
            }
        }

        #endregion // Comparer

        #region .Sort.

        public void Sort()
        {
            base.Sort(KeywordInOtherLanguageCollection.Comparer);
        }

        #endregion
    }


    #endregion

    #region .DrawingKeyword.
    public class DrawingKeyword
    {
        // 提取的关键字
        public string Keyword { get; set; }
        // 关键字其它语言的翻译
        public KeywordInOtherLanguageCollection KeywordsInOtherLanguage { get; set; }
        // 在图纸中的位置
        public KeywordLocationCollection Locations { get; set; }

        public DrawingKeyword()
        {
            Keyword = "";
            KeywordsInOtherLanguage = new KeywordInOtherLanguageCollection();
            Locations = new KeywordLocationCollection();
        }

        public DrawingKeyword(string keyword, KeywordInOtherLanguageCollection keywordsInOtherLanguage, KeywordLocationCollection locations)
        {
            Keyword = "";
            KeywordsInOtherLanguage = new KeywordInOtherLanguageCollection();
            Locations = new KeywordLocationCollection();

            Keyword = keyword;
            KeywordsInOtherLanguage = keywordsInOtherLanguage.Copy();
            Locations = locations.Copy();
        }

        public DrawingKeyword(string keyword, KeywordInOtherLanguageCollection keywordsInOtherLanguage, params KeywordLocation[] locations)
        {
            Keyword = "";
            KeywordsInOtherLanguage = new KeywordInOtherLanguageCollection();
            Locations = new KeywordLocationCollection();

            Keyword = keyword;
            KeywordsInOtherLanguage = keywordsInOtherLanguage.Copy();
            if (locations != null && locations.Length > 0)
                Locations.AddLocations(locations);
        }

        public DrawingKeyword Copy()
        {
            DrawingKeyword keyword = this.MemberwiseClone() as DrawingKeyword;
            if (this.KeywordsInOtherLanguage.Count > 0)
                foreach (KeywordInOtherLanguage kw in this.KeywordsInOtherLanguage)
                    keyword.KeywordsInOtherLanguage.Add(kw.Copy());
            keyword.Locations = this.Locations.Copy();
            return keyword;
        }
    }
    

    public class DrawingKeywordCollection : List<DrawingKeyword>
    {
        public DrawingKeywordCollection()
        {
        }

        #region .Key Index.

        public DrawingKeyword this[string keyword]
        {
            get
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].Keyword == keyword)
                            return (DrawingKeyword)this[i];
                    }
                    return null;
                }
                else
                    return null;
            }
            set
            {
                if (this.Count > 0) {
                    for (int i = 0; i < this.Count; i++) {
                        if (this[i].Keyword == keyword) {
                            this[i] = value;
                            break;
                        }
                    }
                }
                else
                    throw new System.ArgumentOutOfRangeException("Drawing Keyword Index", "No Drawing Keyword with this ID can be found");
            }
        }

        #endregion // Key Index

        #region .Copy.

        /// <summary>
        /// Deep Clone
        /// </summary>
        /// <returns></returns>
        public DrawingKeywordCollection Copy()
        {
            DrawingKeywordCollection drawingKeywords = new DrawingKeywordCollection();

            if (this.Count <= 0)
                return drawingKeywords;
            else {
                foreach (DrawingKeyword drawingKeyword in this)
                    drawingKeywords.Add(drawingKeyword.Copy());
                return drawingKeywords;
            }
        }

        #endregion // Copy

        #region .Comparer.

        public static int Comparer(DrawingKeyword x, DrawingKeyword y)
        {
            if (x.Keyword == null) {
                if (y.Keyword == null) {
                    // If x.Keyword is null and y.Keyword is null, they're
                    // equal. 
                    return 0;
                }
                else {
                    // If x.Keyword is null and y.Keyword is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else {
                // If x.Keyword is not null...
                //
                if (y.Keyword == null)
                // ...and y.Keyword is null, x.Keyword is greater.
                {
                    return 1;
                }
                else {
                    return string.Compare(x.Keyword, y.Keyword /*, true, System.Globalization.CultureInfo.InstalledUICulture*/);
                }
            }
        }

        #endregion // Comparer

        #region .Sort.

        public void Sort()
        {
            base.Sort(DrawingKeywordCollection.Comparer);

            foreach (DrawingKeyword keyword in this) {
                if (keyword.KeywordsInOtherLanguage != null && keyword.KeywordsInOtherLanguage.Count > 0)
                    keyword.KeywordsInOtherLanguage.Sort();
               
                if (keyword.Locations != null && keyword.Locations.Count > 0)
                    keyword.Locations.Sort();
            }
        }

        #endregion

        #region .ContainsKeyword.

        public bool ContainsKeyword(string keyword)
        {
            if (this.Count <= 0)
                return false;
            else
                foreach (DrawingKeyword drawingKeyword in this) {
                    if (drawingKeyword.Keyword == keyword)
                        return true;
                }

            return false;
        }

        #endregion

        #region .AddKeyword.
        public void AddKeyword(DrawingKeyword drawingKeyword)
        {
            if (this.ContainsKeyword(drawingKeyword.Keyword) == true) {
                if (drawingKeyword.Locations != null && drawingKeyword.Locations.Count > 0)
                    this[drawingKeyword.Keyword].Locations.AddLocations(drawingKeyword.Locations);
            } else if (drawingKeyword.Keyword != "")
                this.Add(drawingKeyword);
            else
                return;
        }
        
        #endregion

        #region .AddKeywords.
        public void AddKeywords(DrawingKeywordCollection drawingKeywords)
        {
            if (drawingKeywords != null && drawingKeywords.Count > 0)
                foreach (DrawingKeyword drawingKeyword in drawingKeywords)
                    this.AddKeyword(drawingKeyword);
            else
                return;
            return;
        }

        #endregion
    }

#endregion

}