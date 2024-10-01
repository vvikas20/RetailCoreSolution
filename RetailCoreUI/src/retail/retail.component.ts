import { Component, OnDestroy, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NgxSpinnerModule } from 'ngx-spinner';
import { HttpRequestCounterService } from './core/helper/http-request-counter.service';
import { SpinnerService } from './core/ui-services/spinner.service';
import { Shared_Components } from './shared/components/shared.components.export';
import { Store } from '@ngrx/store';
import { AppState } from './core/states/app.state';
import { selectRequestCounter } from './core/states/request-counter/request-counter.selector';
import { Observable, Subscription, count } from 'rxjs';

@Component({
  selector: 'retail-root',
  standalone: true,
  imports: [RouterOutlet, NgxSpinnerModule, Shared_Components,],
  templateUrl: './retail.component.html',
  styleUrl: './retail.component.scss'
})
export class RetailComponent implements OnInit, OnDestroy {

  title = 'retail-core-ui';

  requestCounterSubsciption: Subscription | undefined;


  constructor(private state: Store<AppState>, private spinnerService: SpinnerService) {

  }


  ngOnInit(): void {
    this.subscribeToHttpRequestCounter();
  }


  ngOnDestroy(): void {
    this.requestCounterSubsciption?.unsubscribe();
  }

  private subscribeToHttpRequestCounter() {
    this.requestCounterSubsciption = this.state.select(selectRequestCounter).subscribe(count => {
      if (count > 0) {
        this.spinnerService.show();
      }
      else {
        this.spinnerService.hide();
      }
    });
  }

}
