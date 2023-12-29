using Core.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Mapping;
using static System.Net.Mime.MediaTypeNames;

namespace View.ViewModels
{
    public class BranchUpdateViewModel : ViewModelBase
    {
        private readonly BranchRepository branchRepository;
        private readonly BranchDTOViewModelMapper branchMapper;
        private string test;

        private ObservableCollection<BranchViewModel> branches;
        public ObservableCollection<BranchViewModel> Branches
        {
            get => branches;
            set
            {
                branches = value;
                OnPropertyChanged(nameof(Branches));
            }
        }

        public BranchUpdateViewModel(BranchRepository branchRepository, BranchDTOViewModelMapper branchMapper)
        {
            this.branchRepository = branchRepository;
            this.branchMapper = branchMapper;
            LoadBranches();
            test = "kuytfut";
        }

        public ApplicationViewModel selectedApplication { get; set; }

        public void SetSelectedApplication(ApplicationViewModel selectedApplication)
        {
            this.selectedApplication = selectedApplication;
        }
        private void LoadBranches()
        {
            var branchesFromCore = branchRepository.GetBranches();
            Branches = new ObservableCollection<BranchViewModel>(branchMapper.MapToViewModelList(branchesFromCore));
        }
        public string Test
        {
            get { return test; }
            set
            {
                test = value;
                OnPropertyChanged(nameof(Test));
            }
        }
    }
}
