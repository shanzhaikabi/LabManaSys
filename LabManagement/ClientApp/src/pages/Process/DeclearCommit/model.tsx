import { Effect, Reducer } from 'umi';
import { queryDeclarationDetail, approveDeclaration, rejectDeclaration } from './service';
import { IChemical, IDeclarationForm } from '@/models/entity';
import { message } from 'antd';

export interface DeclarationProcessModelState {
    detail?: {
        form: IDeclarationForm;
        chemicals: IChemical[]
    }
}

export interface DeclarationProcessModelType {
    namespace: string;
    state: DeclarationProcessModelState;
    effects: {
        fetch: Effect;
        approve: Effect;
        reject: Effect;
    };
    reducers: {
        fetchSuccess: Reducer<DeclarationProcessModelState>;
    };
}

const Model: DeclarationProcessModelType = {
    namespace: 'declarationProcess',

    state: {
    },

    effects: {
        *fetch({ payload }, { call, put }) {
            const response = yield call(queryDeclarationDetail, payload.workflowid);
            console.log(response);
            yield put({
                type: 'fetchSuccess',
                payload: response,
            });
        },
        *approve({ payload }, { call }) {
            yield call(approveDeclaration, payload);
            message.success('提交成功');
        },
        *reject({ payload }, { call }) {
            yield call(rejectDeclaration, payload);
            message.success('提交成功');
        }
    },

    reducers: {
        fetchSuccess(state, action) {
            return {
                ...state,
                detail: {
                    ...action.payload,
                }
            };
        },
    },
};

export default Model;
