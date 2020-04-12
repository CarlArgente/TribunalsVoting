using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TribunalsVoting
{
    /// <summary>
    /// Interaction logic for PositionArtsScienceRepresentative.xaml
    /// </summary>
    public partial class PositionArtsScienceRepresentative : UserControl
    {
        static List<String> list = new List<String>();
        static List<String> list2 = new List<String>();
        static List<String> names = new List<String>();


        void setter()
        {
            var bc = new BrushConverter();
            //Stack Panels
            StackPanel motherPanel = new StackPanel
            {
                Orientation = Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            for (int x = 0; x < SetterForCandidates.listID.Count; x++)
            {
                StackPanel sp = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Width = Double.NaN,
                    Margin = new System.Windows.Thickness(20),
                    Background = new SolidColorBrush(Colors.White),
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                StackPanel spChild = new StackPanel
                {
                    Margin = new System.Windows.Thickness(15),
                    Orientation = Orientation.Vertical,
                };
                StackPanel spSuperChild = new StackPanel
                {
                    Orientation = Orientation.Horizontal
                };
                StackPanel spGrandChild = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                    Margin = new System.Windows.Thickness(10)
                };
                StackPanel spGrandChild2 = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                    Margin = new System.Windows.Thickness(10)
                };
                StackPanel spSuperChild2 = new StackPanel
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                //Button
                Button btnVote = new Button
                {
                    Width = 115,
                    Height = 35,
                    Background = (Brush)bc.ConvertFrom("#FF3827B4"),
                    Content = "Vote",
                    FontSize = 12,
                    Foreground = new SolidColorBrush(Colors.White),
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new System.Windows.Thickness(5),
                    BorderThickness = new System.Windows.Thickness(0)
                };
                //TextBlocks
                TextBlock textName = new TextBlock
                {
                    Name = "txtName",
                    Text = SetterForCandidates.listName[x] + "\t(" + SetterForCandidates.listNickname[x] + ")",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new System.Windows.Thickness(5),
                    FontSize = 14,
                    FontWeight = FontWeights.Medium

                };
                TextBlock textPartylist = new TextBlock
                {
                    Name = "txtPartylist",
                    Text = SetterForCandidates.listPartylist[x],
                    HorizontalAlignment = HorizontalAlignment.Center,
                    FontSize = 13,
                    FontWeight = FontWeights.Regular
                };
                TextBlock textAchievement = new TextBlock
                {
                    Text = "Achievement",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    FontWeight = FontWeights.Light,
                    FontSize = 14,
                    Margin = new System.Windows.Thickness(5),
                    Foreground = (Brush)bc.ConvertFrom("#FF3827B4")
                };
                TextBlock textListAchievement = new TextBlock
                {
                    //      Text = SetterForCandidates.titleAchievement[x].ToString(),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    FontWeight = FontWeights.Regular,
                    Margin = new System.Windows.Thickness(5),
                    Foreground = new SolidColorBrush(Colors.Black)
                };
                TextBlock textPlatform = new TextBlock
                {
                    Text = "Platform",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    FontWeight = FontWeights.Light,
                    FontSize = 14,
                    Margin = new System.Windows.Thickness(5),
                    Foreground = (Brush)bc.ConvertFrom("#FF3827B4")
                };
                TextBlock textLisPlatform = new TextBlock
                {
                    //    Text = "Gold award, Annual Report: Educational School",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    FontWeight = FontWeights.Regular,
                    Margin = new System.Windows.Thickness(5),
                    Foreground = new SolidColorBrush(Colors.Black)
                };

                motherPanel.Children.Add(sp);
                sp.Children.Add(spChild);

                spChild.Children.Add(textName);
                spChild.Children.Add(textPartylist);

                spChild.Children.Add(spSuperChild);
                spChild.Children.Add(spSuperChild2);

                spSuperChild.Children.Add(spGrandChild);
                spGrandChild.Children.Add(textAchievement);
                spGrandChild.Children.Add(textListAchievement);

                spSuperChild2.Children.Add(btnVote);

                spSuperChild.Children.Add(spGrandChild2);
                spGrandChild2.Children.Add(textPlatform);
                //for candidate achievement list
                for (int y = 0; y < list.Count; y++)
                {
                    if (list[y].Equals("|"))
                    {
                        list.RemoveAt(y);
                        break;
                    }
                    textListAchievement.Text += list[y].ToString() + "\r";
                    list[y] = "";
                }
                while (list.Remove("")) { }
                //for candidate platform list
                for (int y = 0; y < list2.Count; y++)
                {
                    if (list2[y].Equals("|"))
                    {
                        list2.RemoveAt(y);
                        break;
                    }
                    textLisPlatform.Text += list2[y].ToString() + "\r";
                    list2[y] = "";
                }
                while (list2.Remove("")) { }
                //for buttons             
                btnVote.Click += btn_Click;
                btnVote.Tag = SetterForCandidates.listName[x].ToString();
                spGrandChild2.Children.Add(textLisPlatform);

            }
            SetterForCandidates.listID.Clear();
            SetterForCandidates.listName.Clear();
            SetterForCandidates.listPartylist.Clear();
            SetterForCandidates.listNickname.Clear();
            SetterForCandidates.listAchievement.Clear();
            SetterForCandidates.listPlatform.Clear();
            Principal.Children.Add(motherPanel);

        }

        void Greetings()
        {
            Ballot ballot = (Ballot)Window.GetWindow(this);

            if (ballot.txtPresident.Text.Equals("") || ballot.txtVPAcademicAffair.Text.Equals("") || ballot.txtVPExternalAffair.Text.Equals("") || ballot.txtVPInternalAffair.Text.Equals("") || ballot.txtVPFinance.Text.Equals("") ||
                ballot.txtVPOperation.Text.Equals("") || ballot.txtRepresentative.Text.Equals(""))
            {
                //do nothing
            }
            else
            {
                MessageBox.Show("Alright! You`re done, click Submit vote if you`re sure!", "Login Successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button buttonThatWasClicked = (Button)sender;
            Ballot ballot = (Ballot)Window.GetWindow(this);
            ballot.txtRepresentative.Text = buttonThatWasClicked.Tag.ToString();
            Greetings();
        }
        public PositionArtsScienceRepresentative()
        {
            InitializeComponent();
            SetterForCandidates.getCandidateInfo("Arts and Science Representative");
            for (int y = 0; y < SetterForCandidates.listAchievement.Count; y++)
            {
                list.Add(SetterForCandidates.listAchievement[y].ToString());
            }
            for (int x = 0; x < SetterForCandidates.listPlatform.Count; x++)
            {

                list2.Add(SetterForCandidates.listPlatform[x].ToString());
            }
            setter();
        }
    }
}
