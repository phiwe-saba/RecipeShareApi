import { Component, OnInit, Type } from '@angular/core';
import { HttpProviderService } from '../../Services/http-provider.service';
import { Router } from '@angular/router';
/*
@Component({
  selector: 'ng-modal-confirm',
  templateUrl: `<div class="modal-header">
    <h5 class="modal-title" id="modal-title">Delete Confirmation</h5>
    <button type="button" class="btn close" aria-label="Close button" aria-describedby="modal-title" (click)="modal.dismiss('Cross click')">
      <span aria-hidden="true">×</span>
    </button>
  </div>
  <div class="modal-body">
    <p>Are you sure you want to delete?</p>
  </div>
  <div class="modal-footer">
    <button type="button" class="btn btn-outline-secondary" (click)="modal.dismiss('cancel click')">CANCEL</button>
    <button type="button" ngbAutofocus class="btn btn-success" (click)="modal.close('Ok click')">OK</button>
  </div>
  `,
  styleUrl: './home.component.css'
})

export class NgModalConfirm {
  constructor(public modal: NgbActiveModal) {}
}

const MODALS: { [name: string]: Type<any> } = {
  deleteModel: NgModalConfirm,
};
*/
@Component({
  selector: 'app-home',
  standalone: false,
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})

export class HomeComponent {}
/*
export class HomeComponent implements OnInit{
  closeResult = '';
  recipeList: any = [];
  constructor(private router: Router, private modalService: NgbModal,
  private toastr: ToastrService, private httpProvider : HttpProviderService) { }

  ngOnInit(): void {
    this.getAllRecipes();
  }
  async getAllRecipes() {
    this.httpProvider.getAllRecipes().subscribe((data : any) => {
      if (data != null && data.body != null) {
        var resultData = data.body;
        if (resultData) {
          this.recipeList = resultData;
        }
      }
    },
    (error : any)=> {
        if (error) {
          if (error.status == 404) {
            if(error.error && error.error.message){
              this.recipeList = [];
            }
          }
        }
      });
  }

  AddRecipe() {
    this.router.navigate(['AddRecipe']);
  }

  deleteRecipeConfirmation(recipe: any) {
    this.modalService.open(MODALS['deleteModal'],
      {
        ariaLabelledBy: 'modal-basic-title'
      }).result.then((result) => {
        this.deleteRecipe(recipe);
      },
        (reason) => {});
  }

  deleteRecipe(employee: any) {
    this.httpProvider.deleteRecipeById(employee.id).subscribe((data : any) => {
      if (data != null && data.body != null) {
        var resultData = data.body;
        if (resultData != null && resultData.isSuccess) {
          this.toastr.success(resultData.message);
          this.getAllRecipes();
        }
      }
    },
    (error : any) => {});
  }
}*/