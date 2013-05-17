using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;


namespace SpleiseKalkulator.ViewModels
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        [System.Runtime.Serialization.IgnoreDataMemberAttribute]
        private Brush amountColor;
        [System.Runtime.Serialization.IgnoreDataMemberAttribute]
        public Brush AmountColor
        {
            get
            {
                return amountColor;
            }
            set
            {
                if (value != amountColor)
                {
                    amountColor = value;
                    NotifyPropertyChanged("AmountColor");
                }
            }
        }
        
        private double amount;
        public double Amount
        {
                get
                {

                    return amount;
                }
                set
                {
                if (value != amount)
                {
                    amount = value;
                    if(amount >0)
                    {
                        AmountColor = new SolidColorBrush(new Color()
                        {
                            A = 255 /*Opacity*/,
                            R = 255 /*Red*/,
                            G = 3 /*Green*/,
                            B = 3 /*Blue*/
                        });
                        LineTwo = "I am in dept to: ";
                    }
                    else
                    {
                        AmountColor = new SolidColorBrush(new Color()
                        {
                           
                            A = 255 /*Opacity*/,
                            R = 0 /*Red*/,
                            G = 255 /*Green*/,
                            B = 9 /*Blue*/
                        });
                        LineTwo = "Is in dept to me: ";
                    }
                    NotifyPropertyChanged("Amount");
                    NotifyPropertyChanged("AmountAsString");
                }
            }
        }

        public string AmountAsString
        {
            get
            {
                if (Amount < 0)
                {
                    string n = amount.ToString();
                    return n.Substring(1, n.Length-1);
                }
                else
                {
                    return amount.ToString();
                }
                
            }
        }

        private string bgColor;
        public string BgColor
        {
            get
            {
                return bgColor;
            }
            set
            {
                if (value != bgColor)
                {
                    bgColor = value;
                    NotifyPropertyChanged("BgColor");

                }
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != name)
                {
                    name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }


        private string _lineOne;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string LineOne
        {
            get
            {
                return _lineOne;
            }
            set
            {
                if (value != _lineOne)
                {
                    _lineOne = value;
                    NotifyPropertyChanged("LineOne");
                  
                }
            }
        }

        private string _lineTwo;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string LineTwo
        {
            get
            {
                return _lineTwo;
            }
            set
            {
                if (value != _lineTwo)
                {
                    _lineTwo = value;
                    NotifyPropertyChanged("LineTwo");
                }
            }
        }

        private string _lineThree;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string LineThree
        {
            get
            {
                return _lineThree;
            }
            set
            {
                if (value != _lineThree)
                {
                    _lineThree = value;
                    NotifyPropertyChanged("LineThree");
                }
            }
        }

        private string _profilePicture;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string ProfilePicture
        {
            get
            {
                return _profilePicture;
            }
            set
            {
                if (value != _profilePicture)
                {
                    _profilePicture = value;
                    NotifyPropertyChanged("ProfilePicture");
                }
            }
        }
        // won't store this in the isolated storage.
        [System.Runtime.Serialization.IgnoreDataMemberAttribute]
        private BitmapImage _p = null;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        /// 
        
        [System.Runtime.Serialization.IgnoreDataMemberAttribute]
        public BitmapImage ProfileBitMap
        {
            get
            {
                return _p;
            }
            set
            {
                if (value != _p)
                {
                    _p = value;
                    NotifyPropertyChanged("ProfileBitMap");
                }
            }
        }

        [System.Runtime.Serialization.IgnoreDataMemberAttribute]
        private BitmapImage _pp = null;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        /// 

        [System.Runtime.Serialization.IgnoreDataMemberAttribute]
        public BitmapImage PicOfMyself
        {
            get
            {
                return _pp;
            }
            set
            {
                if (value != _pp)
                {
                    _pp = value;
                    NotifyPropertyChanged("PicOfMyself");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}