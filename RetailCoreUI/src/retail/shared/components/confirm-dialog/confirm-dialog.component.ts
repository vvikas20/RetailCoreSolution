import { Component } from '@angular/core';
import { ConfirmDialogModule } from 'primeng/confirmdialog';

@Component({
  selector: 'retail-confirm-dialog',
  standalone: true,
  imports: [ConfirmDialogModule],
  templateUrl: './confirm-dialog.component.html',
  styleUrl: './confirm-dialog.component.scss'
})
export class ConfirmDialogComponent {

}
