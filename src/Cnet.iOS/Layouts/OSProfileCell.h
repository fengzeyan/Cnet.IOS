//
//  OSProfileCell.h
//  College Nannies and Tutors Layouts
//
//  Created by kristian.lien on 3/20/14.
//  Copyright (c) 2014 Onsharp. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface OSProfileCell : UITableViewCell
{
    IBOutlet UIImageView *iconImage;
    IBOutlet UILabel *profileLabel;
    IBOutlet UIImageView *phoneIconImage;
}

@property(nonatomic, strong) IBOutlet UIImageView *iconImage;
@property(nonatomic, strong) IBOutlet UILabel *profileLabel;
@property(nonatomic, strong) IBOutlet UIImageView *phoneIconImage;

@end
