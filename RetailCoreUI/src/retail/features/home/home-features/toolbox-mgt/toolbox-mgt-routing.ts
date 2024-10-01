import { Routes } from "@angular/router";
import { ToolboxMgtComponent } from "./toolbox-mgt.component";
import { ToolboxComponent } from "./pages/toolbox/toolbox.component";

const ToolboxMgtComponent_Routes: Routes = [
    {
        path: '', component: ToolboxMgtComponent,
        children: [
            { path: '', redirectTo: 'my-project', pathMatch: 'full' },
            { path: 'toolbox', component: ToolboxComponent },
        ]
    }
];

export { ToolboxMgtComponent_Routes }