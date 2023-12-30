using Core.Data.Repositories;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using View.Mapping;
using static System.Net.Mime.MediaTypeNames;

namespace View.ViewModels
{
    public class BranchUpdateViewModel : ViewModelBase
    {
        private readonly BranchRepository branchRepository;
        private readonly BranchDTOViewModelMapper branchMapper;
        private readonly ApplicationRepository applicationRepository;

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

        public BranchUpdateViewModel(BranchRepository branchRepository, BranchDTOViewModelMapper branchMapper, ApplicationRepository applicationRepository)
        {
            this.branchRepository = branchRepository;
            this.branchMapper = branchMapper;
            this.applicationRepository = applicationRepository;
            LoadBranches();
        }

        private ApplicationViewModel selectedApplication { get; set; }
        private int selectedBranch;
        public int SelectedBranch
        {
            get => selectedBranch;
            set
            {
                selectedBranch = value;
                OnPropertyChanged(nameof(SelectedBranch));
            }
        }
        private RelayCommand updateBranchCommand;
        public RelayCommand UpdateBranchCommand
        {
            get
            {
                return updateBranchCommand ?? (updateBranchCommand = new RelayCommand(ExecuteUpdateBranchCommand));
            }
        }

        private void ExecuteUpdateBranchCommand()
        {
            if (selectedApplication != null)
            {
                applicationRepository.UpdateBranchInApplication(selectedApplication.Id, SelectedBranch);
            }
            var window = System.Windows.Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);

            window?.Close();
        }
        public void SetSelectedApplication(ApplicationViewModel selectedApplication)
        {
            this.selectedApplication = selectedApplication;
            SelectedBranch = Branches.SingleOrDefault(c => c.Name == this.selectedApplication.Branch).Id;
        }
        private void LoadBranches()
        {
            var branchesFromCore = branchRepository.GetBranches();
            Branches = new ObservableCollection<BranchViewModel>(branchMapper.MapToViewModelList(branchesFromCore));
        }
    }
}
