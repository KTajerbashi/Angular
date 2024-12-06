import { Component } from '@angular/core';

@Component({
  selector: 'app-footer',
  imports: [],
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.css',
})
export class FooterComponent {
  currentYear: number = new Date().getFullYear();

  openSocial(platform: string): void {
    const socialLinks: { [key: string]: string } = {
      facebook: 'https://www.facebook.com',
      twitter: 'https://www.twitter.com',
      linkedin: 'https://www.linkedin.com',
    };

    if (socialLinks[platform]) {
      window.open(socialLinks[platform], '_blank');
    }
  }
}
