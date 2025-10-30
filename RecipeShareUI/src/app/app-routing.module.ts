import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Recipes/home/home.component';
import { ViewRecipeComponent } from './Recipes/view-recipe/view-recipe.component';
import { EditRecipeComponent } from './Recipes/edit-recipe/edit-recipe.component';

const routes: Routes = [
  { path: '', redirectTo: 'Home', pathMatch: 'full'},
  { path: 'Home', component: HomeComponent},
  { path: 'ViewRecipe/:id', component: ViewRecipeComponent},
  { path: 'EditRecipe/:id', component: EditRecipeComponent},
  //{ path: 'AddRecipe', component: AddRecipeComponent}
  {
    path: 'AddRecipe',
    loadComponent: () =>
      import('./Recipes/add-recipe/add-recipe.component').then(
        (m) => m.AddRecipeComponent
      ),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
