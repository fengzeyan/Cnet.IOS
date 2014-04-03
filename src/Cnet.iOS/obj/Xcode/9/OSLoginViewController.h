// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>


@interface OSLoginViewController : UIViewController {
	UITextField *_tbxPassword;
	UITextField *_tbxUsername;
}

@property (nonatomic, retain) IBOutlet UITextField *tbxPassword;

@property (nonatomic, retain) IBOutlet UITextField *tbxUsername;

- (IBAction)loginButtonClick:(UIButton *)sender;

@end
