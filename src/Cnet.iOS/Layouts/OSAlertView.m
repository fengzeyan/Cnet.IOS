//
//  OSAlertView.m
//  College Nannies and Tutors Layouts
//
//  Created by kristian.lien on 3/28/14.
//  Copyright (c) 2014 Onsharp. All rights reserved.
//

#import "OSAlertView.h"

@implementation OSAlertView

#pragma mark -
#pragma mark Graphics Methods

-(void)layoutSubviews
{
    for (UIView *subview in self.subviews)
    {
        if ([subview isMemberOfClass:[UIImageView class]])
        {
            //subview.hidden = YES; //Hide UIImageView Containing Blue Background
        }
        
        if ([subview isMemberOfClass:[UILabel class]])
        {
            //Point to UILabels To Change Text
            UILabel *label = (UILabel*)subview; //Cast From UIView to UILabel
            label.textColor = [UIColor colorWithRed:210.0f/255.0f green:210.0f/255.0f blue:210.0f/255.0f alpha:1.0f];
            label.shadowColor = [UIColor blackColor];
            label.shadowOffset = CGSizeMake(0.0f, 1.0f);
        }
    }
}

#pragma mark -
#pragma mark Class Methods

- (id)initWithFrame:(CGRect)frame
{
    self = [super initWithFrame:frame];
    if (self) {
        // Initialization code
    }
    return self;
}

/*
// Only override drawRect: if you perform custom drawing.
// An empty implementation adversely affects performance during animation.
- (void)drawRect:(CGRect)rect
{
    // Drawing code
}
*/

@end
