import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { registerLicense } from '@syncfusion/ej2-base';

registerLicense('Ngo9BigBOggjHTQxAR8/V1NHaF5cXmVCf1JpRmNGfV5yd0VDallUTnRbUiweQnxTdEZiWXxfcHFQQ2JZVER3Vg==');
platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));
