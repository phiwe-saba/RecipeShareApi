import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HttpProviderService } from '../../Services/http-provider.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-recipe',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './add-recipe.component.html',
  styleUrls: ['./add-recipe.component.css']
})
export class AddRecipeComponent implements OnInit {
  recipeForm!: FormGroup;
  isSubmitted = false;

  constructor(
    private fb: FormBuilder,
    private httpProvider: HttpProviderService,
    private toastr: ToastrService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.recipeForm = this.fb.group({
      title: ['', [Validators.required, Validators.maxLength(100)]],
      ingredients: this.fb.array([this.fb.control('', Validators.required)]),
      steps: this.fb.array([this.fb.control('', Validators.required)]),
      cookingTime: ['', [Validators.required, Validators.pattern(/^[1-9]\d*$/)]],
      dietaryTag: ['']
    });
  }

  get ingredients() {
    return this.recipeForm.get('ingredients') as FormArray;
  }

  get steps() {
    return this.recipeForm.get('steps') as FormArray;
  }

  addIngredient() {
    this.ingredients.push(this.fb.control('', Validators.required));
  }

  removeIngredient(index: number) {
    this.ingredients.removeAt(index);
  }

  addStep() {
    this.steps.push(this.fb.control('', Validators.required));
  }

  removeStep(index: number) {
    this.steps.removeAt(index);
  }

  onSubmit() {
    this.isSubmitted = true;

    if (this.recipeForm.invalid) {
      this.toastr.error('Please fix validation errors before submitting.');
      return;
    }

    const recipeData = this.recipeForm.value;

    this.httpProvider.addRecipe(recipeData).subscribe({
      next: () => {
        this.toastr.success('Recipe added successfully!');
        this.router.navigate(['/Home']);
      },
      error: (err) => {
        console.error(err);
        this.toastr.error('Error saving recipe.');
      }
    });
  }
}
