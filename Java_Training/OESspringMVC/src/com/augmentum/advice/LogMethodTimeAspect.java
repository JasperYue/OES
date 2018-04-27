package com.augmentum.advice;

import org.apache.log4j.Logger;
import org.aspectj.lang.JoinPoint;
import org.aspectj.lang.ProceedingJoinPoint;

import com.augmentum.Constants;
import com.augmentum.WebContext;
import com.augmentum.model.User;

/**
 * AOP for logging user operation.
 */
public class LogMethodTimeAspect {

    private final Logger logger = Logger.getLogger(LogMethodTimeAspect.class);

    public void doAfter(JoinPoint jp) {
        User user = (User) (WebContext.getContext().getVal(Constants.APP_CONTEXT_USER));

        if (user != null) {
            logger.info(user.getName() + " OUT method: " + jp.getSignature().getName());
        }
    }

    public Object doAround(ProceedingJoinPoint pjp) throws Throwable {
        User user = (User) (WebContext.getContext().getVal(Constants.APP_CONTEXT_USER));

        long startTime = System.currentTimeMillis();

        Object returnValue = pjp.proceed();
        String methodName = pjp.getSignature().getName();
        long endTime = System.currentTimeMillis();
        if (user != null) {
            StringBuilder sb = new StringBuilder();
            sb.append(user.getName());
            sb.append(" : ");
            sb.append(pjp.getTarget().getClass().getSimpleName());
            sb.append(" : ");
            sb.append(methodName);
            sb.append(" : ");
            sb.append(endTime-startTime);

            logger.info(sb.toString());
        }
        return returnValue;

    }

    public void doBefore(JoinPoint jp) {
        User user = (User) (WebContext.getContext().getVal(Constants.APP_CONTEXT_USER));

        if (user != null) {
            logger.info(user.getName() + " IN method: " + jp.getSignature().getName());
        }
    }

    public void doThrowing(JoinPoint jp, Throwable ex) {
        User user = (User) (WebContext.getContext().getVal(Constants.APP_CONTEXT_USER));

        if (user != null) {
            logger.info(user.getName() + " IN method: " + jp.getSignature().getName() + " Throw Exception " + ex.getMessage());
        }
    }
}
