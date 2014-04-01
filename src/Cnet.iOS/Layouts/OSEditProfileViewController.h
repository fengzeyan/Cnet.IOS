//
//  OSEditProfileViewController.h
//  College Nannies and Tutors Layouts
//
//  Created by kristian.lien on 3/20/14.
//  Copyright (c) 2014 Onsharp. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface OSEditProfileViewController : UIViewController
{
    IBOutlet UIScrollView *editProfileScrollView;
    IBOutlet UITextField *firstNameTextField;
    IBOutlet UITextField *lastNameTextField;
    IBOutlet UITextField *emailTextField;
    IBOutlet UITextField *phoneTextField;
    IBOutlet UITextField *addressTextField;
    IBOutlet UITextField *addressLine2TextField;
    IBOutlet UITextField *cityTextField;
    IBOutlet UITextField *stateTextField;
    IBOutlet UITextField *zipCodeTextField;
    IBOutlet UITextField *emergencyContactTextField;
    IBOutlet UITextField *ecPhoneTextField;
}

@property(nonatomic, strong) IBOutlet UIScrollView *editProfileScrollView;
@property(nonatomic, strong) IBOutlet UITextField *firstNameTextField;
@property(nonatomic, strong) IBOutlet UITextField *lastNameTextField;
@property(nonatomic, strong) IBOutlet UITextField *emailTextField;
@property(nonatomic, strong) IBOutlet UITextField *phoneTextField;
@property(nonatomic, strong) IBOutlet UITextField *addressTextField;
@property(nonatomic, strong) IBOutlet UITextField *addressLine2TextField;
@property(nonatomic, strong) IBOutlet UITextField *cityTextField;
@property(nonatomic, strong) IBOutlet UITextField *stateTextField;
@property(nonatomic, strong) IBOutlet UITextField *zipCodeTextField;
@property(nonatomic, strong) IBOutlet UITextField *emergencyContactTextField;
@property(nonatomic, strong) IBOutlet UITextField *ecPhoneTextField;

@end
