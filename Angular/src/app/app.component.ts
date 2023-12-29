import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'AngularBigBang';
  role: string = localStorage.getItem('role') || '';
  constructor(private router:Router) {
      
  }
  ngOnInit(): void {
     
    
   
    const menu: HTMLElement | null = document.querySelector('#menu-icon');
    const navbar: HTMLElement | null = document.querySelector('.navbar');

    if (menu && navbar) {
      menu.onclick = () => {
        menu.classList.toggle('bx-x');
        navbar.classList.toggle('open');
      };
    }
    }
  logOutPage() {
    localStorage.removeItem("token");
    localStorage.removeItem("role");
    this.router.navigate(['login']).then(() => {
      // Optional: Scroll to the top of the page
      window.scrollTo(0, 0);
      location.reload();

    });
  }   
}
