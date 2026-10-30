using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace TV_Шаповалова.Classes
{
    public class TV
    {
        private int activeChannel = 0;
        private int activeVolume = 5;
        private bool isOn = false;

        public List<Channel> Channels = new List<Channel>();

        public bool IsOn
        {
            get { return isOn; }
            set { isOn = value; }
        }

        public int ActiveChannel
        {
            get { return activeChannel; }
            set
            {
                if (value < 0)
                    activeChannel = Channels.Count - 1;
                else if (value >= Channels.Count)
                    activeChannel = 0;
                else
                    activeChannel = value;
            }
        }

        public TV()
        {
            Channels.Add(new Channel()
            {
                Name = "Практическое занятие №3 Объявление классов и создание объектов в C#.mp4",
                Src = @"C:\Users\aooshepkov\Dowloads\1.mp4"
            });
            Channels.Add(new Channel()
            {
                Name = "Практическое занятие №4 Использование методов ООП Разница между простыми и статистическими методами.mp4",
                Src = @"C:\Users\aooshepkov\Dowloads\2.mp4"
            });
            Channels.Add(new Channel()
            {
                Name = "Практическое занятие №4 Конструкторы в ООП.mp4",
                Src = @"C:\Users\aooshepkov\Dowloads\2.mp4"
            });
            Channels.Add(new Channel()
            {
                Name = "Четвертый канал",
                Src = @"C:\Users\aooshepkov\Dowloads\4.mp4"
            });
            Channels.Add(new Channel()
            {
                Name = "Пятый канал",
                Src = @"C:\Users\aooshepkov\Dowloads\5.mp4"
            });
            Channels.Add(new Channel()
            {
                Name = "Шестой канал",
                Src = @"C:\Users\aooshepkov\Dowloads\6.mp4"
            });
            Channels.Add(new Channel()
            {
                Name = "Седьмой канал",
                Src = @"C:\Users\aooshepkov\Dowloads\7.mp4"
            });
            Channels.Add(new Channel()
            {
                Name = "Восьмой канал",
                Src = @"C:\Users\aooshepkov\Dowloads\8.mp4"
            });
            Channels.Add(new Channel()
            {
                Name = "Девятый канал",
                Src = @"C:\Users\aooshepkov\Dowloads\9.mp4"
            });
            Channels.Add(new Channel()
            {
                Name = "Десятый канал",
                Src = @"C:\Users\aooshepkov\Dowloads\10.mp4"
            });
            Channels.Add(new Channel()
            {
                Name = "Одиннадцатый канал",
                Src = @"C:\Users\aooshepkov\Dowloads\11.mp4"
            });
            Channels.Add(new Channel()
            {
                Name = "Двенадцатый канал",
                Src = @"C:\Users\aooshepkov\Dowloads\12.mp4"
            });
            Channels.Add(new Channel()
            {
                Name = "Тринадцатый канал",
                Src = @"C:\Users\aooshepkov\Dowloads\13.mp4"
            });
            Channels.Add(new Channel()
            {
                Name = "Четырнадцатый канал",
                Src = @"C:\Users\aooshepkov\Dowloads\14.mp4"
            });
        }

        public void Power(MediaElement _MediaElement, TextBlock _NameChannel, Button _PowerButton)
        {
            IsOn = !IsOn;

            if (IsOn)
            {
                _MediaElement.Source = new Uri(Channels[ActiveChannel].Src);
                _MediaElement.Volume = activeVolume / 10.0;
                _MediaElement.Play();
                _NameChannel.Text = Channels[ActiveChannel].Name;
                _PowerButton.Content = "Выключить";
                _MediaElement.Opacity = 1;
            }
            else
            {
                _MediaElement.Stop();
                _NameChannel.Text = "Телевизор выключен";
                _PowerButton.Content = "Включить";
                _MediaElement.Opacity = 0;
            }
        }

        public void SwapChanell(MediaElement _MediaElement, TextBlock _NameChannel)
        {
            if (!IsOn) return;

            DoubleAnimation StartAnimation = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.6)
            };
            StartAnimation.Completed += delegate
            {
                _MediaElement.Source = new Uri(Channels[ActiveChannel].Src);
                _MediaElement.Play();

                DoubleAnimation EndAnimation = new DoubleAnimation
                {
                    From = 0,
                    To = 1,
                    Duration = TimeSpan.FromSeconds(0.6)
                };
                _MediaElement.BeginAnimation(MediaElement.OpacityProperty, EndAnimation);
            };
            _MediaElement.BeginAnimation(MediaElement.OpacityProperty, StartAnimation);
            _NameChannel.Text = Channels[ActiveChannel].Name;
        }

        public void NextChannel(MediaElement _MediaElement, TextBlock _NameChannel)
        {
            if (!IsOn) return;
            ActiveChannel++;
            SwapChanell(_MediaElement, _NameChannel);
        }

        public void BackChannel(MediaElement _MediaElement, TextBlock _NameChannel)
        {
            if (!IsOn) return;
            ActiveChannel--;
            SwapChanell(_MediaElement, _NameChannel);
        }

        public void UpSound(MediaElement _MediaElement)
        {
            if (activeVolume < 10) activeVolume++;
            _MediaElement.Volume = activeVolume / 10.0;
        }

        public void DownSound(MediaElement _MediaElement)
        {
            if (activeVolume > 0) activeVolume--;
            _MediaElement.Volume = activeVolume / 10.0;
        }
    }
}