import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Recipes/home/home.component';
import { ViewRecipeComponent } from './Recipes/view-recipe/view-recipe.component';
import { EditRecipeComponent } from './Recipes/edit-recipe/edit-recipe.component';
import { AddRecipeComponent } from './Recipes/add-recipe/add-recipe.component';

const routes: Routes = [
  { path: '', redirectTo: 'Home', pathMatch: 'full'},
  { path: 'Home', component: HomeComponent},
  { path: 'ViewRecipe/:recipeId', component: ViewRecipeComponent},
  { path: 'EditRecipe/:emploeeId', component: EditRecipeComponent},
  { path: 'AddRecipe', component: AddRecipeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
