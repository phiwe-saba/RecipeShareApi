import { Component, OnInit, Type } from '@angular/core';
import { Router, RouterModule  } from '@angular/router';
import { NgbModal, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { HttpProviderService } from '../../Services/http-provider.service';
import { NgModalConfirm } from '../../ng-modal-confirm/ng-modal-confirm.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, RouterModule, NgbModule, ToastrModule],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit { 
  recipeList: any[] = [];

  constructor(
    private router: Router,
    private modalService: NgbModal,
    private toastr: ToastrService,
    private httpProvider: HttpProviderService
  ) {}

  ngOnInit(): void {
    this.getAllRecipes();
  }

  getAllRecipes() {
    this.httpProvider.getAllRecipes().subscribe(
      (data: any) => {
        this.recipeList = data?.body ?? [];
      },
      (error: any) => {
        if (error?.status === 404) {
          this.recipeList = [];
        }
      }
    );
  }

  AddRecipe() {
    this.router.navigate(['AddRecipe']);
  }

  deleteRecipeConfirmation(recipe: any) {
    const modalRef = this.modalService.open(NgModalConfirm);
    modalRef.result.then(
      () => this.deleteRecipe(recipe),
      () => {}
    );
  }

  deleteRecipe(recipe: any) {
    this.httpProvider.deleteRecipeById(recipe.id).subscribe(
      (data: any) => {
        const resultData = data?.body;
        if (resultData?.isSuccess) {
          this.toastr.success(resultData.message);
          this.getAllRecipes();
        }
      },
      () => {}
    );
  }
}
