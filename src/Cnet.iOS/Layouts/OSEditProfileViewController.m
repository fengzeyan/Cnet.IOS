//
//  OSEditProfileViewController.m
//  College Nannies and Tutors Layouts
//
//  Created by kristian.lien on 3/20/14.
//  Copyright (c) 2014 Onsharp. All rights reserved.
//

#import "OSEditProfileViewController.h"

@interface OSEditProfileViewController ()
@end

@implementation OSEditProfileViewController

@synthesize editProfileScrollView, firstNameTextField, lastNameTextField, emailTextField, phoneTextField, addressTextField, addressLine2TextField, cityTextField, stateTextField,
            zipCodeTextField, emergencyContactTextField, ecPhoneTextField;

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        // Custom initialization
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    // Do any additional setup after loading the view.
    
    // Set custom height for text views and add image
    NSArray *textFieldArray = [NSArray arrayWithObjects:firstNameTextField, lastNameTextField, emailTextField, phoneTextField,
                               emergencyContactTextField, ecPhoneTextField, nil];
    NSArray *textFieldImageArray = [NSArray arrayWithObjects:@"icon-user.png", @"icon-user.png", @"icon-mail.png", @"icon-mobile.png",
                                    @"icon-user.png", @"icon-phone.png", nil];
    for (int i = 0; i < [textFieldArray count]; i++)
    {
        // Resize height to 43 px (cant change height in IB)
        UITextField *tempTextField = [textFieldArray objectAtIndex:i];
        CGRect frameRect = [tempTextField frame];
        frameRect.size.height = 43;
        [tempTextField setFrame:frameRect];
        
        // Indent text and set image
        [tempTextField setLeftViewMode:UITextFieldViewModeAlways];
        UIImageView *spacerView = [[UIImageView alloc] initWithFrame:CGRectMake(0, 0, 40, 24)];
        [spacerView setImage:[UIImage imageNamed:[textFieldImageArray objectAtIndex:i]]];
        [spacerView setContentMode:UIViewContentModeCenter];
        [[textFieldArray objectAtIndex:i] setLeftView:spacerView];
    }
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/

@end
