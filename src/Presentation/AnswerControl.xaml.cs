﻿using System.Windows.Controls;
using Domain;
using Presentation.View;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for AnswerControl.xaml
    /// </summary>
    public partial class AnswerControl : UserControl
    {
        public AnswerControl()
        {
            InitializeComponent();

            //            AllBinaryAnswersView
            var allBinaryAnswersView = new AllBinaryAnswersView();

            var allBinaryAnswersViewModel = new AllBinaryAnswersViewModel(DependencyResolver.Resolve<ICurrentFormHolder>(),
               Stage.Pre, x => x.BinaryAnswers);
            allBinaryAnswersView.DataContext = allBinaryAnswersViewModel;

            Eins.Children.Add(allBinaryAnswersView);

            //            AllSongsAnswerView
            var allSongAnswersView = new AllBinaryAnswersView();

            var allSongAnswersViewModel = new AllBinaryAnswersViewModel(DependencyResolver.Resolve<ICurrentFormHolder>(),
                Stage.Pre, x => x.SongAnswers);
            allSongAnswersView.DataContext = allSongAnswersViewModel;

            Zwei.Children.Add(allSongAnswersView);

            //            GradeAnswerView

            var allGradeAnswersView = new AllGradeAnswersView();

            var allGradeAnswersViewModel = new AllGradeAnswersViewModel(DependencyResolver.Resolve<ICurrentFormHolder>(),
                 Stage.Pre);
            allGradeAnswersView.DataContext = allGradeAnswersViewModel;

            Drei.Children.Add(allGradeAnswersView);

            //            TextAnswersView

            var allTextAnswersView = new AllTextAnswersView();

            var allTextAnswersViewModel = new AllTextAnswersViewModel(DependencyResolver.Resolve<ICurrentFormHolder>(),
                 Stage.Pre);
            allTextAnswersView.DataContext = allTextAnswersViewModel;

            Vier.Children.Add(allTextAnswersView);
        }
    }
}
